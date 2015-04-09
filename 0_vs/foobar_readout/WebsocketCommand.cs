using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace foobar_readout
{
    class WebsocketCommand
    {
        [JsonProperty("command")]
        public string Command;
        [JsonProperty("key")]
        private string Key = "ga";
        [JsonProperty("values")]
        public WebsocketValues Values;

        public WebsocketCommand(string command, WebsocketValues values)
        {
            Command = command;
            Values = values;
        }
    }
}
