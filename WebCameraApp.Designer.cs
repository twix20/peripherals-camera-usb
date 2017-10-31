namespace MyCamera
{
    partial class WebCameraApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebCameraApp));
            this.pbView = new System.Windows.Forms.PictureBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.btnVideoFormat = new System.Windows.Forms.Button();
            this.btnVideoSource = new System.Windows.Forms.Button();
            this.btnCapturePhoto = new System.Windows.Forms.Button();
            this.btnVideoCapture = new System.Windows.Forms.Button();
            this.btnWww = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pbView
            // 
            this.pbView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbView.Location = new System.Drawing.Point(12, 12);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(519, 478);
            this.pbView.TabIndex = 0;
            this.pbView.TabStop = false;
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(12, 496);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(519, 24);
            this.cbDevices.TabIndex = 1;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.cbDevices_SelectedIndexChanged);
            // 
            // btnVideoFormat
            // 
            this.btnVideoFormat.Location = new System.Drawing.Point(537, 12);
            this.btnVideoFormat.Name = "btnVideoFormat";
            this.btnVideoFormat.Size = new System.Drawing.Size(110, 47);
            this.btnVideoFormat.TabIndex = 2;
            this.btnVideoFormat.Text = "Video Format";
            this.btnVideoFormat.UseVisualStyleBackColor = true;
            this.btnVideoFormat.Click += new System.EventHandler(this.btnVideoFormat_Click);
            // 
            // btnVideoSource
            // 
            this.btnVideoSource.Location = new System.Drawing.Point(537, 65);
            this.btnVideoSource.Name = "btnVideoSource";
            this.btnVideoSource.Size = new System.Drawing.Size(110, 47);
            this.btnVideoSource.TabIndex = 3;
            this.btnVideoSource.Text = "Video Source";
            this.btnVideoSource.UseVisualStyleBackColor = true;
            this.btnVideoSource.Click += new System.EventHandler(this.btnVideoSource_Click);
            // 
            // btnCapturePhoto
            // 
            this.btnCapturePhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCapturePhoto.BackgroundImage")));
            this.btnCapturePhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapturePhoto.Location = new System.Drawing.Point(552, 130);
            this.btnCapturePhoto.Name = "btnCapturePhoto";
            this.btnCapturePhoto.Size = new System.Drawing.Size(78, 72);
            this.btnCapturePhoto.TabIndex = 4;
            this.btnCapturePhoto.UseVisualStyleBackColor = true;
            this.btnCapturePhoto.Click += new System.EventHandler(this.btnCapturePhoto_Click);
            // 
            // btnVideoCapture
            // 
            this.btnVideoCapture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVideoCapture.BackgroundImage")));
            this.btnVideoCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoCapture.Location = new System.Drawing.Point(552, 208);
            this.btnVideoCapture.Name = "btnVideoCapture";
            this.btnVideoCapture.Size = new System.Drawing.Size(78, 72);
            this.btnVideoCapture.TabIndex = 5;
            this.btnVideoCapture.UseVisualStyleBackColor = true;
            this.btnVideoCapture.Click += new System.EventHandler(this.btnVideoCapture_Click);
            // 
            // btnWww
            // 
            this.btnWww.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWww.BackgroundImage")));
            this.btnWww.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWww.Location = new System.Drawing.Point(552, 286);
            this.btnWww.Name = "btnWww";
            this.btnWww.Size = new System.Drawing.Size(78, 72);
            this.btnWww.TabIndex = 6;
            this.btnWww.UseVisualStyleBackColor = true;
            this.btnWww.Click += new System.EventHandler(this.btnWww_Click);
            // 
            // WebCameraApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 532);
            this.Controls.Add(this.btnWww);
            this.Controls.Add(this.btnVideoCapture);
            this.Controls.Add(this.btnCapturePhoto);
            this.Controls.Add(this.btnVideoSource);
            this.Controls.Add(this.btnVideoFormat);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.pbView);
            this.Name = "WebCameraApp";
            this.Text = "WebCameraApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebCameraApp_FormClosing);
            this.Load += new System.EventHandler(this.WebCameraApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Button btnVideoFormat;
        private System.Windows.Forms.Button btnVideoSource;
        private System.Windows.Forms.Button btnCapturePhoto;
        private System.Windows.Forms.Button btnVideoCapture;
        private System.Windows.Forms.Button btnWww;
    }
}

