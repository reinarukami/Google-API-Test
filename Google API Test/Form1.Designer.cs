using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace Google_API_Test
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
            this.components = new System.ComponentModel.Container();
            this.ListImages = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.newPicture = new System.Windows.Forms.PictureBox();
            this.DeleteComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.newPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ListImages
            // 
            this.ListImages.FormattingEnabled = true;
            this.ListImages.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ListImages.Location = new System.Drawing.Point(254, 263);
            this.ListImages.Name = "ListImages";
            this.ListImages.Size = new System.Drawing.Size(231, 24);
            this.ListImages.TabIndex = 0;
            this.ListImages.SelectedIndexChanged += new System.EventHandler(this.ListImages_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // newPicture
            // 
            this.newPicture.Location = new System.Drawing.Point(254, 12);
            this.newPicture.Name = "newPicture";
            this.newPicture.Size = new System.Drawing.Size(482, 245);
            this.newPicture.TabIndex = 2;
            this.newPicture.TabStop = false;
            // 
            // DeleteComboBox
            // 
            this.DeleteComboBox.FormattingEnabled = true;
            this.DeleteComboBox.Location = new System.Drawing.Point(254, 326);
            this.DeleteComboBox.Name = "DeleteComboBox";
            this.DeleteComboBox.Size = new System.Drawing.Size(231, 24);
            this.DeleteComboBox.TabIndex = 3;
            this.DeleteComboBox.SelectedIndexChanged += new System.EventHandler(this.DeleteComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 454);
            this.Controls.Add(this.DeleteComboBox);
            this.Controls.Add(this.newPicture);
            this.Controls.Add(this.ListImages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ListImages;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox newPicture;
        private System.Windows.Forms.ComboBox DeleteComboBox;
    }
}

