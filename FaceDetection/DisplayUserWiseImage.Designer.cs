namespace FaceDetection
{
    partial class DisplayUserWiseImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayUserWiseImage));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            this.lblFaceCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User List : ";
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(108, 23);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(214, 21);
            this.cmbUser.TabIndex = 1;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // picBox1
            // 
            this.picBox1.Image = global::FaceDetection.Properties.Resources.blank_pp;
            this.picBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBox1.InitialImage")));
            this.picBox1.Location = new System.Drawing.Point(25, 66);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(128, 128);
            this.picBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox1.TabIndex = 7;
            this.picBox1.TabStop = false;
            // 
            // picBox2
            // 
            this.picBox2.Image = global::FaceDetection.Properties.Resources.blank_pp;
            this.picBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBox2.InitialImage")));
            this.picBox2.Location = new System.Drawing.Point(159, 66);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(128, 128);
            this.picBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox2.TabIndex = 8;
            this.picBox2.TabStop = false;
            // 
            // picBox3
            // 
            this.picBox3.Image = global::FaceDetection.Properties.Resources.blank_pp;
            this.picBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBox3.InitialImage")));
            this.picBox3.Location = new System.Drawing.Point(294, 66);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(128, 128);
            this.picBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox3.TabIndex = 9;
            this.picBox3.TabStop = false;
            // 
            // lblFaceCount
            // 
            this.lblFaceCount.AutoSize = true;
            this.lblFaceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaceCount.Location = new System.Drawing.Point(329, 24);
            this.lblFaceCount.Name = "lblFaceCount";
            this.lblFaceCount.Size = new System.Drawing.Size(0, 18);
            this.lblFaceCount.TabIndex = 10;
            // 
            // DisplayUserWiseImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 276);
            this.Controls.Add(this.lblFaceCount);
            this.Controls.Add(this.picBox3);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label1);
            this.Name = "DisplayUserWiseImage";
            this.Text = "DisplayUserWiseImage";
            this.Load += new System.EventHandler(this.DisplayUserWiseImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox3;
        private System.Windows.Forms.Label lblFaceCount;
    }
}