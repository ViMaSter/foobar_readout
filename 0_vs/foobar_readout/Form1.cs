using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using WebSocket4Net;

namespace foobar_readout
{

    public partial class Form1 : Form
    {

        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeValues();
            InitializeWebsocket();
        }

        // Thread-handler
        private bool initialStart = true;
        private bool valuesPending = false;

        // Websocket
        public WebSocket ws;
       
        public void InitializeWebsocket() {
            ws = new WebSocket("ws://st-livestream.herokuapp.com/");
            ws.Opened += new EventHandler(websocket_Opened);
            ws.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
            ws.Closed += new EventHandler(websocket_Closed);
            ws.MessageReceived += new EventHandler<WebSocket4Net.MessageReceivedEventArgs>(websocket_MessageReceived);
            ws.Open();
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Open!");
            ws.Send("{\"command\":\"get\",\"key\":\"\"}");
        }

        private void websocket_Error(object sender, EventArgs e)
        {
            Console.WriteLine("Error!");
        }

        private void websocket_Closed(object sender, EventArgs e)
        {
            InitializeWebsocket();
            Console.WriteLine("Closed!");
        }

        private void websocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            WebsocketResponse response = JsonConvert.DeserializeObject<WebsocketResponse>(e.Message);
            switch (response.Command)
            {
                case "get_request":
                    if (response.Values == null)
                    {
                        return;
                    }

                    if (LocalValues != ServerValues && !initialStart)
                    {
                        ServerValues = response.Values;
                        valuesPending = true;
                        this.Invoke((MethodInvoker)(() => this.Refresh()));
                    }
                    else
                    {
                        ServerValues = response.Values;
                        initialStart = false;
                        this.Invoke((MethodInvoker)(() => this.UpdateLocalWithServer()));
                        this.Invoke((MethodInvoker)(() => this.Refresh()));
                    }
                    break;
            }
        }

        // Values
        public static WebsocketValues ServerValues = new WebsocketValues();
        public static WebsocketValues LocalValues  = new WebsocketValues();

        public void InitializeValues() {
            LocalValues.Music = new MusicValues();
            LocalValues.Music.Artist = "Artist1";
            LocalValues.Music.Track = "Track2";
            LocalValues.Music.Album = "Album3";
        }

        public void UpdateLocalWithServer() {
            LocalValues = DeepCopy<WebsocketValues>(ServerValues);
            valuesPending = false;

            meta_artist_input.Text = LocalValues.Music.Artist;
            meta_track_input.Text = LocalValues.Music.Track;
            meta_album_input.Text = LocalValues.Music.Album;
            meta_album_artwork_input.Text = LocalValues.Music.Album_Artwork;
            server_forceHide.Checked = LocalValues.Music.ForceHide;
        }

        public void UpdateServerWithLocal() {
            WebsocketCommand sendCommand = new WebsocketCommand("set", LocalValues);
            ws.Send(JsonConvert.SerializeObject(sendCommand));
            ws.Send("{\"command\":\"get\",\"key\":\"\"}");
        }

        // Foobar lookup
        public bool AutomaticallyUpdateUsingFoobar = false;
        public IntPtr Handle;
        public Timer FoobarUpdateTimer;

        public void ToggleTimer(bool state)
        {
            if (state)
            {
                FoobarUpdateTimer = new Timer();
                FoobarUpdateTimer.Tick += new EventHandler(UpdateFoobar);
                FoobarUpdateTimer.Interval = 1000;
                FoobarUpdateTimer.Start();
            }
            else
            {
                FoobarUpdateTimer.Stop();
            }
        }

        public void UpdateFoobar(object sender, EventArgs e)
        {
            if (Handle != IntPtr.Zero && Handle != null)
            {
                // get the title when we have a process handle
                int maxLength = 0;
                StringBuilder title = new StringBuilder(256);
                UnsafeNativeMethods.GetWindowText(Handle, title, title.Capacity);
                string foobar2000Title = title.ToString();
                MatchCollection content = Regex.Matches(foobar2000Title, @"\[([^\[\]]*)\]");

                if (!foobar2000Title.Contains("foobar"))
                {
                    Handle = IntPtr.Zero;
                    return;
                }

                if (content.Count < 3 )
                {
                    Console.WriteLine("foobar seems to be running but isn't playing.");
                    LocalValues.Music.Artist = "";
                    LocalValues.Music.Track = "";
                    LocalValues.Music.Album = "";
                    UpdateServerWithLocal();
                }
                else
                {
                    LocalValues.Music.Artist = content[0].Groups[1].ToString();
                    LocalValues.Music.Track = content[1].Groups[1].ToString();
                    LocalValues.Music.Album = content[2].Groups[1].ToString();
                    if (LocalValues != ServerValues)
                    {
                        UpdateServerWithLocal();
                    }
                }
            }
            else
            {
                // find the process handle of foobar2k
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("foobar2000");
                if (processes.Length > 0)
                {
                    Handle = processes[0].MainWindowHandle;
                }
                else
                {
                    Handle = IntPtr.Zero;
                    Console.WriteLine("No foobar-process found.");
                    LocalValues.Music.Artist = "";
                    LocalValues.Music.Track = "";
                    LocalValues.Music.Album = "";
                    UpdateServerWithLocal();
                }

                foreach (var process in processes)
                {
                    process.Dispose();
                }
            }
        }

        // Form events
        private void meta_artist_input_TextChanged(object sender, EventArgs e)
        {
            LocalValues.Music.Artist = meta_artist_input.Text;
        }

        private void meta_track_input_TextChanged(object sender, EventArgs e)
        {
            LocalValues.Music.Track = meta_track_input.Text;
        }

        private void meta_album_input_TextChanged(object sender, EventArgs e)
        {
            LocalValues.Music.Album = meta_album_input.Text;
        }

        private void meta_album_artwork_input_TextChanged(object sender, EventArgs e)
        {
            LocalValues.Music.Album_Artwork = meta_album_artwork_input.Text;
        }

        private void server_forceHide_CheckedChanged(object sender, EventArgs e)
        {
            LocalValues.Music.ForceHide = server_forceHide.Checked;
        }

        private void updateValues_button_Click(object sender, EventArgs e)
        {
            UpdateServerWithLocal();
        }

        private void forceRefresh_button_Click(object sender, EventArgs e)
        {
            UpdateLocalWithServer();
            ws.Send("{\"command\":\"get\",\"key\":\"\"}");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            eventUpdate_label.Text = valuesPending ? "Server got new values - update will result in overwritten values!" : "";
        }

        private void foobar_button_Click(object sender, EventArgs e)
        {
            UpdateFoobar(this, null);
        }

        private void foobar_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            AutomaticallyUpdateUsingFoobar = foobar_checkbox.Checked;
            ToggleTimer(AutomaticallyUpdateUsingFoobar);
        }
    }
}
