namespace FreeLauncher.Forms.UpdateForm
{
    partial class UpdaterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterForm));
            this.DownloadProgressbar = new Telerik.WinControls.UI.RadProgressBar();
            this.DownloadingLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadProgressbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadingLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DownloadProgressbar
            // 
            this.DownloadProgressbar.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadProgressbar.ForeColor = System.Drawing.Color.Red;
            this.DownloadProgressbar.Location = new System.Drawing.Point(12, 98);
            this.DownloadProgressbar.Name = "DownloadProgressbar";
            this.DownloadProgressbar.ShowProgressIndicators = true;
            this.DownloadProgressbar.Size = new System.Drawing.Size(375, 66);
            this.DownloadProgressbar.TabIndex = 0;
            this.DownloadProgressbar.Text = "0 %";
            this.DownloadProgressbar.ThemeName = "VisualStudio2012Dark";
            // 
            // DownloadingLabel
            // 
            this.DownloadingLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadingLabel.ForeColor = System.Drawing.Color.White;
            this.DownloadingLabel.Location = new System.Drawing.Point(48, 37);
            this.DownloadingLabel.Name = "DownloadingLabel";
            this.DownloadingLabel.Size = new System.Drawing.Size(294, 30);
            this.DownloadingLabel.TabIndex = 1;
            this.DownloadingLabel.Text = "Downloading Launcher Update";
            this.DownloadingLabel.ThemeName = "VisualStudio2012Dark";
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(399, 183);
            this.Controls.Add(this.DownloadingLabel);
            this.Controls.Add(this.DownloadProgressbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdaterForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.DownloadProgressbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadingLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadProgressBar DownloadProgressbar;
        private Telerik.WinControls.UI.RadLabel DownloadingLabel;
    }
}