namespace AnignoLibrary.UI.Multimedia.AudioVolumeGraphing
{
    partial class AudioFileVolumeGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.volumeGraphMain = new AnignoLibrary.UI.Multimedia.AudioVolumeGraphing.VolumeGraph();
            this.SuspendLayout();
            // 
            // volumeGraphMain
            // 
            this.volumeGraphMain.BytesBuffer = null;
            this.volumeGraphMain.BytesPerVerticalLine = 240000;
            this.volumeGraphMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeGraphMain.ForeColor = System.Drawing.Color.White;
            this.volumeGraphMain.GraphColor = System.Drawing.Color.White;
            this.volumeGraphMain.GridColor = System.Drawing.Color.LightGray;
            this.volumeGraphMain.Header = null;
            this.volumeGraphMain.Location = new System.Drawing.Point(0, 0);
            this.volumeGraphMain.MinimumSize = new System.Drawing.Size(50, 20);
            this.volumeGraphMain.Name = "volumeGraphMain";
            this.volumeGraphMain.Size = new System.Drawing.Size(273, 164);
            this.volumeGraphMain.TabIndex = 0;
            // 
            // AudioFileVolumeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.volumeGraphMain);
            this.Name = "AudioFileVolumeGraph";
            this.Size = new System.Drawing.Size(273, 164);
            this.ResumeLayout(false);

        }

        #endregion

        private VolumeGraph volumeGraphMain;

    }
}
