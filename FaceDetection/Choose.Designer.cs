namespace FaceDetection
{
    partial class Choose
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
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.imgBox = new Emgu.CV.UI.ImageBox();
            this.ImageDialouge = new System.Windows.Forms.OpenFileDialog();
            this.lblDetect = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetection = new System.Windows.Forms.Button();
            this.txtDetectScale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNeighbour = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Location = new System.Drawing.Point(175, 21);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "..Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtImageFile
            // 
            this.txtImageFile.Location = new System.Drawing.Point(16, 24);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.Size = new System.Drawing.Size(157, 20);
            this.txtImageFile.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoad.Location = new System.Drawing.Point(16, 50);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(234, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // imgBox
            // 
            this.imgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox.Location = new System.Drawing.Point(13, 13);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(572, 607);
            this.imgBox.TabIndex = 2;
            this.imgBox.TabStop = false;
            // 
            // lblDetect
            // 
            this.lblDetect.AutoSize = true;
            this.lblDetect.Location = new System.Drawing.Point(16, 227);
            this.lblDetect.Name = "lblDetect";
            this.lblDetect.Size = new System.Drawing.Size(0, 13);
            this.lblDetect.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetection);
            this.groupBox1.Controls.Add(this.lblDetect);
            this.groupBox1.Controls.Add(this.txtDetectScale);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNeighbour);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbScale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnChoose);
            this.groupBox1.Controls.Add(this.txtImageFile);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(595, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 607);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Tuning";
            // 
            // btnDetection
            // 
            this.btnDetection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetection.Location = new System.Drawing.Point(16, 175);
            this.btnDetection.Name = "btnDetection";
            this.btnDetection.Size = new System.Drawing.Size(234, 23);
            this.btnDetection.TabIndex = 10;
            this.btnDetection.Text = "Tune detection";
            this.btnDetection.UseVisualStyleBackColor = true;
            this.btnDetection.Click += new System.EventHandler(this.btnDetection_Click);
            // 
            // txtDetectScale
            // 
            this.txtDetectScale.Location = new System.Drawing.Point(126, 140);
            this.txtDetectScale.Name = "txtDetectScale";
            this.txtDetectScale.Size = new System.Drawing.Size(121, 20);
            this.txtDetectScale.TabIndex = 9;
            this.txtDetectScale.Text = "25";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min Detection Scale";
            // 
            // cmbNeighbour
            // 
            this.cmbNeighbour.FormattingEnabled = true;
            this.cmbNeighbour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbNeighbour.Location = new System.Drawing.Point(127, 112);
            this.cmbNeighbour.Name = "cmbNeighbour";
            this.cmbNeighbour.Size = new System.Drawing.Size(121, 21);
            this.cmbNeighbour.TabIndex = 6;
            this.cmbNeighbour.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min Neighbour";
            // 
            // cmbScale
            // 
            this.cmbScale.FormattingEnabled = true;
            this.cmbScale.Items.AddRange(new object[] {
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "1.10",
            "2.2",
            "2.3",
            "2.4",
            "2.5"});
            this.cmbScale.Location = new System.Drawing.Point(127, 85);
            this.cmbScale.Name = "cmbScale";
            this.cmbScale.Size = new System.Drawing.Size(121, 21);
            this.cmbScale.TabIndex = 4;
            this.cmbScale.Text = "1.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scale Increase Rate";
            // 
            // Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 645);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgBox);
            this.Name = "Choose";
            this.Text = "Choose";
            this.Load += new System.EventHandler(this.Choose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtImageFile;
        private System.Windows.Forms.Button btnLoad;
        private Emgu.CV.UI.ImageBox imgBox;
        private System.Windows.Forms.OpenFileDialog ImageDialouge;
        private System.Windows.Forms.Label lblDetect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbNeighbour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetectScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetection;
    }
}