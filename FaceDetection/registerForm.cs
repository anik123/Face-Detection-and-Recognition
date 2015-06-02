using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.EntitySql;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceDetection
{
    public partial class registerForm : Form
    {
        // Trained Xml
        private CascadeClassifier _face;
        private Capture camera;
        private int imgNo = 0;
        private Image<Bgr, byte> frame;
        private Image<Bgr, byte> withoutrectFrame;


        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        private Image<Gray, byte> TrainedFace;


        public registerForm()
        {
            InitializeComponent();
            CaptureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileLoad();
        }


        public void fileLoad()
        {
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //MessageBox.Show(e.ToString());
                // MessageBox.Show("Nothing in binary database, please add at least a face", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            frame = camera.QueryFrame();
            withoutrectFrame = frame.Copy();

            if (frame != null)
            {
                var imageGreyFrame = frame.Convert<Gray, byte>();
                var faces = _face.DetectMultiScale(imageGreyFrame, 1.2, 4, new Size(20, 20), Size.Empty);
                //var faces = imageGreyFrame.DetectHaarCascade(face, 1.2, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];
                if (faces.Length > 0)
                {
                    Bitmap bmpImage = imageGreyFrame.ToBitmap();
                    Bitmap extractedFace; // 
                    Graphics faceCanvus;
                    // _imgList = new List<Bitmap>();

                    // for (int i = 0; i < faces.Length; i++) // (Rectangle face_found in facesDetected)
                    //{
                    //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                    //of the background noise
                    faces[0].X += (int)(faces[0].Height * 0.05);
                    faces[0].Y += (int)(faces[0].Width * 0.15);
                    faces[0].Height -= (int)(faces[0].Height * .1);
                    faces[0].Width -= (int)(faces[0].Width * .1);
                    var result = frame.Copy(faces[0])
                        .Convert<Gray, byte>()
                        .Resize(256, 256, INTER.CV_INTER_CUBIC);
                    result._EqualizeHist();
                    extractedFace = new Bitmap(faces[0].Width, faces[0].Height);
                    faceCanvus = Graphics.FromImage(extractedFace);
                    faceCanvus.DrawImage(bmpImage, 0, 0, faces[0], GraphicsUnit.Pixel);
                    //_imgList.Add(extractedFace);
                    //draw the face detected in the 0th (gray) channel with blue color
                    frame.Draw(faces[0], new Bgr(Color.BlanchedAlmond), 2);






                    // }
                    //detectedImage();
                }
            }

            CaptureBox.Image = frame;

        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            _face = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
            if (camera == null)
            {
                camera = new Capture();
                Application.Idle += ProcessFrame;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var face = extractImage(withoutrectFrame); //withoutrectFrame.Convert<Gray, byte>().ToBitmap();
            if (imgNo == 0)
            {
                //picBox1.Image = frame.ToBitmap();

                if (face != null)
                {
                    picBox1.Image = face.ToBitmap();
                    TrainedFace = face;
                    imgNo++;
                }
            }
            /*  else if (imgNo == 1)
              {

                  if (face != null)
                  {
                      picBox2.Image = new Bitmap(face, new Size(100, 100));
                      imgNo++;
                  }
              }
              else if (imgNo == 2)
              {
                  if (face != null)
                  {
                      picBox3.Image = new Bitmap(face, new Size(100, 100));
                      imgNo++;
                  }
              }*/
        }

        private Image<Gray, byte> extractImage(Image<Bgr, Byte> img)
        {
            var imageGreyFrame = img.Convert<Gray, byte>();

            var faces = _face.DetectMultiScale(imageGreyFrame, 1.2, 4, new Size(25, 25), Size.Empty);
            //var faces = imageGreyFrame.DetectHaarCascade(face, 1.2, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];
            if (faces.Length > 0)
            {
                Bitmap bmpImage = imageGreyFrame.ToBitmap();
                Bitmap extractedFace; // 
                Graphics faceCanvus;
                // _imgList = new List<Bitmap>();


                //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                //of the background noise
                faces[0].X += (int)(faces[0].Height * 0.05);
                faces[0].Y += (int)(faces[0].Width * 0.15);
                faces[0].Height -= (int)(faces[0].Height * .1);
                faces[0].Width -= (int)(faces[0].Width * .1);
                var result = img.Copy(faces[0])
                    .Convert<Gray, byte>()
                    .Resize(100, 100, INTER.CV_INTER_CUBIC);
                /*result._EqualizeHist();
                extractedFace = new Bitmap(faces[0].Width, faces[0].Height);
                faceCanvus = Graphics.FromImage(extractedFace);
                faceCanvus.DrawImage(bmpImage, 0, 0, faces[0], GraphicsUnit.Pixel);
                 * */
                //_imgList.Add(extractedFace);
                return result;
            }
            return null;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length <= 0)
            {
                MessageBox.Show("User Full Name is required");
                txtUserName.Focus();
                return;
            }
            /*if (imgNo <= 2)
            {
                MessageBox.Show("three Image is required");
                //txtUserName.Focus();
                return;
            }*/

            /* var user = new User();
             user.FullName = txtUserName.Text;

             // userImage.Images=picBox1
             //ForeColor()
             for (int i = 0; i < 3; i++)
             {
                 var userImage = new UserImage();
                 if (i == 0)
                     userImage.Images = ImageCompressions(picBox1.Image);
                 else if (i == 1)
                     userImage.Images = ImageCompressions(picBox2.Image);
                 else if (i == 2)
                     userImage.Images = ImageCompressions(picBox3.Image);
                 user.ImageList.Add(userImage);
             }
             DbTransaction db = new DbTransaction();
             db.addFace(user);
             MessageBox.Show("Successfully Created");
             */



            trainingImages.Add(TrainedFace);
            labels.Add(txtUserName.Text);

            //Write the number of triained faces in a file text for further load
            File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

            //Write the labels of triained faces in a file text for further load
            for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
            {
                trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
            }


            txtUserName.Text = "";
            picBox1.Image = FaceDetection.Properties.Resources.blank_pp;
            picBox2.Image = FaceDetection.Properties.Resources.blank_pp;
            picBox3.Image = FaceDetection.Properties.Resources.blank_pp;
            imgNo = 0;

        }
        private byte[] ImageCompressions(Image img)
        {
            var bmp = new Bitmap(img);
            var memory = new MemoryStream();
            bmp.Save(memory, ImageFormat.Jpeg);
            var imgBytes = memory.ToArray();
            return imgBytes;
        }

    }
}
