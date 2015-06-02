using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceDetection
{
    public partial class Choose : Form
    {
        private HaarCascade detect;
        private Capture capture;
        private Image<Bgr, Byte> ImageFrame = null;

        public Choose()
        {
            InitializeComponent();
            //imgBox.Size = new Size(572, 607);
            imgBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            try
            {
                Image InputImg = Image.FromFile(txtImageFile.Text);
                ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                if (ImageFrame != null)
                {
                    var image = ImageFrame.Convert<Gray, byte>();
                    double a;
                    int b;
                    var faces = image.DetectHaarCascade(detect, double.TryParse(cmbScale.SelectedItem.ToString(), out a) ? double.Parse(cmbScale.SelectedItem.ToString()) : 1.4, int.TryParse(cmbNeighbour.SelectedItem.ToString(), out b) ? int.Parse(cmbNeighbour.SelectedItem.ToString()) : 3, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];
                    foreach (var face in faces)
                    {
                        ImageFrame.Draw(face.rect, new Bgr(Color.BlanchedAlmond), 3);
                    }
                    // detect only first image
                    lblDetect.Text = faces.Length + " Detected";
                }
                //ImageFrame.Size = new Size(572, 607);
                imgBox.Image = ImageFrame;
                Application.Idle -= ProcessFrame;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Image");
            }

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (ImageDialouge.ShowDialog() == DialogResult.OK)
            {
                txtImageFile.Text = ImageDialouge.FileName;
            }
        }

        private void Choose_Load(object sender, EventArgs e)
        {
            detect = new HaarCascade("haarcascade_frontalface_default.xml");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            startCaption();
        }

        public void startCaption()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtImageFile.Text))
                {
                    if (capture != null)
                        Application.Idle -= ProcessFrame;
                    capture = new Capture(txtImageFile.Text);
                    Application.Idle += ProcessFrame;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Image");
            }
        }

        private void btnDetection_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtImageFile.Text))
                startCaption();
        }


    }
}
