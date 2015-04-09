namespace foobar_readout
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.meta_artist_input = new System.Windows.Forms.TextBox();
            this.meta_artist_label = new System.Windows.Forms.Label();
            this.meta_track_label = new System.Windows.Forms.Label();
            this.meta_track_input = new System.Windows.Forms.TextBox();
            this.meta_album_label = new System.Windows.Forms.Label();
            this.meta_album_input = new System.Windows.Forms.TextBox();
            this.updateValues_button = new System.Windows.Forms.Button();
            this.server_forceHide = new System.Windows.Forms.CheckBox();
            this.forceRefresh_button = new System.Windows.Forms.Button();
            this.eventUpdate_label = new System.Windows.Forms.Label();
            this.foobar_button = new System.Windows.Forms.Button();
            this.foobar_checkbox = new System.Windows.Forms.CheckBox();
            this.meta_album_artwork_label = new System.Windows.Forms.Label();
            this.meta_album_artwork_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // meta_artist_input
            // 
            this.meta_artist_input.Location = new System.Drawing.Point(267, 10);
            this.meta_artist_input.Name = "meta_artist_input";
            this.meta_artist_input.Size = new System.Drawing.Size(275, 20);
            this.meta_artist_input.TabIndex = 0;
            this.meta_artist_input.TextChanged += new System.EventHandler(this.meta_artist_input_TextChanged);
            // 
            // meta_artist_label
            // 
            this.meta_artist_label.Location = new System.Drawing.Point(12, 13);
            this.meta_artist_label.Name = "meta_artist_label";
            this.meta_artist_label.Size = new System.Drawing.Size(256, 17);
            this.meta_artist_label.TabIndex = 1;
            this.meta_artist_label.Text = "Artist";
            // 
            // meta_track_label
            // 
            this.meta_track_label.Location = new System.Drawing.Point(12, 39);
            this.meta_track_label.Name = "meta_track_label";
            this.meta_track_label.Size = new System.Drawing.Size(256, 17);
            this.meta_track_label.TabIndex = 3;
            this.meta_track_label.Text = "Track";
            // 
            // meta_track_input
            // 
            this.meta_track_input.Location = new System.Drawing.Point(267, 36);
            this.meta_track_input.Name = "meta_track_input";
            this.meta_track_input.Size = new System.Drawing.Size(275, 20);
            this.meta_track_input.TabIndex = 2;
            this.meta_track_input.TextChanged += new System.EventHandler(this.meta_track_input_TextChanged);
            // 
            // meta_album_label
            // 
            this.meta_album_label.Location = new System.Drawing.Point(12, 65);
            this.meta_album_label.Name = "meta_album_label";
            this.meta_album_label.Size = new System.Drawing.Size(256, 17);
            this.meta_album_label.TabIndex = 5;
            this.meta_album_label.Text = "Album";
            // 
            // meta_album_input
            // 
            this.meta_album_input.Location = new System.Drawing.Point(267, 62);
            this.meta_album_input.Name = "meta_album_input";
            this.meta_album_input.Size = new System.Drawing.Size(275, 20);
            this.meta_album_input.TabIndex = 4;
            this.meta_album_input.TextChanged += new System.EventHandler(this.meta_album_input_TextChanged);
            // 
            // meta_album_artwork_label
            // 
            this.meta_album_artwork_label.Location = new System.Drawing.Point(11, 91);
            this.meta_album_artwork_label.Name = "meta_album_artwork_label";
            this.meta_album_artwork_label.Size = new System.Drawing.Size(256, 17);
            this.meta_album_artwork_label.TabIndex = 15;
            this.meta_album_artwork_label.Text = "Album-Artwork";
            // 
            // meta_album_artwork_input
            // 
            this.meta_album_artwork_input.Location = new System.Drawing.Point(266, 88);
            this.meta_album_artwork_input.Name = "meta_album_artwork_input";
            this.meta_album_artwork_input.Size = new System.Drawing.Size(275, 20);
            this.meta_album_artwork_input.TabIndex = 14;
            this.meta_album_artwork_input.TextChanged += new System.EventHandler(this.meta_album_artwork_input_TextChanged);
            // 
            // updateValues_button
            // 
            this.updateValues_button.Location = new System.Drawing.Point(437, 178);
            this.updateValues_button.Name = "updateValues_button";
            this.updateValues_button.Size = new System.Drawing.Size(105, 23);
            this.updateValues_button.TabIndex = 8;
            this.updateValues_button.Text = "Update Values";
            this.updateValues_button.UseVisualStyleBackColor = true;
            this.updateValues_button.Click += new System.EventHandler(this.updateValues_button_Click);
            // 
            // server_forceHide
            // 
            this.server_forceHide.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.server_forceHide.Location = new System.Drawing.Point(10, 113);
            this.server_forceHide.Name = "server_forceHide";
            this.server_forceHide.Size = new System.Drawing.Size(529, 24);
            this.server_forceHide.TabIndex = 9;
            this.server_forceHide.Text = "Force Hide";
            this.server_forceHide.UseVisualStyleBackColor = true;
            this.server_forceHide.CheckedChanged += new System.EventHandler(this.server_forceHide_CheckedChanged);
            // 
            // forceRefresh_button
            // 
            this.forceRefresh_button.Location = new System.Drawing.Point(326, 178);
            this.forceRefresh_button.Name = "forceRefresh_button";
            this.forceRefresh_button.Size = new System.Drawing.Size(105, 23);
            this.forceRefresh_button.TabIndex = 10;
            this.forceRefresh_button.Text = "Force Refresh";
            this.forceRefresh_button.UseVisualStyleBackColor = true;
            this.forceRefresh_button.Click += new System.EventHandler(this.forceRefresh_button_Click);
            // 
            // eventUpdate_label
            // 
            this.eventUpdate_label.ForeColor = System.Drawing.Color.Brown;
            this.eventUpdate_label.Location = new System.Drawing.Point(12, 134);
            this.eventUpdate_label.Name = "eventUpdate_label";
            this.eventUpdate_label.Size = new System.Drawing.Size(308, 18);
            this.eventUpdate_label.TabIndex = 11;
            // 
            // foobar_button
            // 
            this.foobar_button.Location = new System.Drawing.Point(12, 178);
            this.foobar_button.Name = "foobar_button";
            this.foobar_button.Size = new System.Drawing.Size(146, 23);
            this.foobar_button.TabIndex = 12;
            this.foobar_button.Text = "Look for foobar2k";
            this.foobar_button.UseVisualStyleBackColor = true;
            this.foobar_button.Click += new System.EventHandler(this.foobar_button_Click);
            // 
            // foobar_checkbox
            // 
            this.foobar_checkbox.AutoSize = true;
            this.foobar_checkbox.Location = new System.Drawing.Point(12, 155);
            this.foobar_checkbox.Name = "foobar_checkbox";
            this.foobar_checkbox.Size = new System.Drawing.Size(144, 17);
            this.foobar_checkbox.TabIndex = 13;
            this.foobar_checkbox.Text = "Automatically use Foobar";
            this.foobar_checkbox.UseVisualStyleBackColor = true;
            this.foobar_checkbox.CheckedChanged += new System.EventHandler(this.foobar_checkbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 213);
            this.Controls.Add(this.meta_album_artwork_label);
            this.Controls.Add(this.meta_album_artwork_input);
            this.Controls.Add(this.foobar_checkbox);
            this.Controls.Add(this.foobar_button);
            this.Controls.Add(this.eventUpdate_label);
            this.Controls.Add(this.forceRefresh_button);
            this.Controls.Add(this.server_forceHide);
            this.Controls.Add(this.updateValues_button);
            this.Controls.Add(this.meta_album_label);
            this.Controls.Add(this.meta_album_input);
            this.Controls.Add(this.meta_track_label);
            this.Controls.Add(this.meta_track_input);
            this.Controls.Add(this.meta_artist_label);
            this.Controls.Add(this.meta_artist_input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox meta_artist_input;
        private System.Windows.Forms.Label meta_artist_label;
        private System.Windows.Forms.Label meta_track_label;
        private System.Windows.Forms.TextBox meta_track_input;
        private System.Windows.Forms.Label meta_album_label;
        private System.Windows.Forms.TextBox meta_album_input;
        private System.Windows.Forms.Button updateValues_button;
        private System.Windows.Forms.CheckBox server_forceHide;
        private System.Windows.Forms.Button forceRefresh_button;
        private System.Windows.Forms.Label eventUpdate_label;
        private System.Windows.Forms.Button foobar_button;
        private System.Windows.Forms.CheckBox foobar_checkbox;
        private System.Windows.Forms.Label meta_album_artwork_label;
        private System.Windows.Forms.TextBox meta_album_artwork_input;
    }
}

