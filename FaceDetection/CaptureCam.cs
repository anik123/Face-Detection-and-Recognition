using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace FaceDetection
{
    public partial class CaptureCam : Form
    {
        // Capture tool
        private Capture _capture;

        private bool captureInProgress;
        private List<string> _imageList = new List<string>();
        private Image<Bgr, Byte> _imageFrame = null;
        private Image<Gray, byte> imageGreyFrame = null;
        private int count = 0;
        private DbTransaction _db = new DbTransaction();

        private List<KeyValuePair<int, string>> deviceInfo = new List<KeyValuePair<int, string>>();
        private List<string> imgLabel = new List<string>();
        private List<int> imgIDs = new List<int>();
        private List<Image<Gray, byte>> _trainImageList = new List<Image<Gray, byte>>();

        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5); //Our fount for writing within the frame

        // Trained Xml
        private CascadeClassifier _face;
        private HaarCascade _eye;

        private double zoom = 1.0;
        private List<Bitmap> _imgList;

        // Threading
        private BackgroundWorker bgWorker;
        private Recognizer _recognizer;


        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        private Image<Gray, byte> TrainedFace;


        public CaptureCam()
        {
            InitializeComponent();
            //loadData();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnCapture.Enabled = false;
            DeviceList();
            CamImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            loadTrainningSet();
        }


        private void loadTrainningSet()
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
            catch (Exception ex)
            {

            }
        }

        private void loadData()
        {
            try
            {
                var dataList = _db.fetechImage();
                imgLabel = dataList.Select(o => o.FullName).ToList();
                int count = 0;
                foreach (var label in imgLabel)
                {
                    imgIDs.Add(count++);
                }
                foreach (var data in dataList)
                {
                    var img = new Bitmap(ImageDecompress(data.Image), new Size(100, 100));
                    var grayImg = new Image<Gray, Byte>(img);
                    _trainImageList.Add(grayImg);
                }
                // _recognizer = new Recognizer(_trainImageList, imgIDs, imgLabel);
                // _recognizer.loadRecognizer();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeviceList()
        {
            var cameraList = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int deviceIndex = 0;
            foreach (var camera in cameraList)
            {
                deviceInfo.Add(new KeyValuePair<int, string>(deviceIndex, camera.Name));
                deviceIndex++;
            }

            cmbDeviceList.DataSource = deviceInfo;
            cmbDeviceList.ValueMember = "Key";
            cmbDeviceList.DisplayMember = "Value";
        }
        /*
        private void ProcessFrame(object sender, EventArgs arg)
        {

            _imgList = new List<Bitmap>();
            _imageFrame = _capture.QueryFrame();  //line 1

            if (_imageFrame != null)
            {
                imageGreyFrame = _imageFrame.Convert<Gray, byte>();
                var faces = _face.DetectMultiScale(imageGreyFrame, 1.2, 4, new Size(25, 25), Size.Empty);
                //var faces = imageGreyFrame.DetectHaarCascade(face, 1.2, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];
                if (faces.Length > 0)
                {
                    Bitmap bmpImage = imageGreyFrame.ToBitmap();
                    Bitmap extractedFace; // 
                    Graphics faceCanvus;
                    _imgList = new List<Bitmap>();

                    for (int i = 0; i < faces.Length; i++) // (Rectangle face_found in facesDetected)
                    {
                        //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                        //of the background noise
                        faces[i].X += (int)(faces[i].Height * 0.05);
                        faces[i].Y += (int)(faces[i].Width * 0.15);
                        faces[i].Height -= (int)(faces[i].Height * .1);
                        faces[i].Width -= (int)(faces[i].Width * .1);
                        var result = _imageFrame.Copy(faces[i])
                            .Convert<Gray, byte>()
                            .Resize(100, 100, INTER.CV_INTER_CUBIC);
                        result._EqualizeHist();
                        extractedFace = new Bitmap(faces[i].Width, faces[i].Height);
                        faceCanvus = Graphics.FromImage(extractedFace);
                        faceCanvus.DrawImage(bmpImage, 0, 0, faces[i], GraphicsUnit.Pixel);
                        _imgList.Add(extractedFace);
                        //draw the face detected in the 0th (gray) channel with blue color
                        _imageFrame.Draw(faces[i], new Bgr(Color.BlanchedAlmond), 2);



                        if (_recognizer.isTrained)
                        {
                            string name = _recognizer.recognize(result);
                            name = name ?? "Null Pase";
                            Console.WriteLine(name);
                            int match_value = (int)_recognizer.Get_Eigen_Distance;

                            //Draw the label for each face detected and recognized
                            _imageFrame.Draw(name + " ", ref font, new Point(faces[i].X - 2, faces[i].Y - 2), new Bgr(Color.LightGreen));
                            //ADD_Face_Found(result, name, match_value);
                        }


                    }
                    // detectedImage();
                }
                lblUser.Text = faces.Length.ToString();
            }

            CamImageBox.Image = _imageFrame;

        }*/
        /*
        private void detectedImage()
        {
            panel1.Controls.Clear();
            var count = 0;
            var point = new Point(15, 0);
            foreach (var img in _imgList)
            {
                var pic = new PictureBox();
                //var imagePath = @"E:\" + ++count + ".jpg";
                //ImageFrame.Save(imagePath);
                pic.Image = img;
                pic.Name = "pic" + ++count;
                pic.Height = 128;
                pic.Width = 128;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                pic.Location = count == 1 ? new Point(point.X, point.Y) : new Point(point.X, point.Y + 140);
                pic.Click += img_Click;
                panel1.Controls.Add(pic);
                point = new Point(pic.Location.X, pic.Location.Y);
            }

        }*/

        private void btnStart_Click(object sender, EventArgs e)
        {
            #region if capture is not created, create it now

            if (_capture == null)
            {
                try
                {
                    _capture = cmbDeviceList.Items.Count > 0 ? new Capture(int.Parse(cmbDeviceList.SelectedValue.ToString())) : new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if (_capture != null)
            {
                Application.Idle += FrameGrabber_Parrellel;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnCapture.Enabled = true;
            }

            #endregion
        }
        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_capture != null)
                Application.Idle -= FrameGrabber_Parrellel;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnCapture.Enabled = false;
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            //PictureBox pic = new PictureBox();
            //var imagePath = @"E:\" + ++count + ".jpg";
            //ImageFrame.Save(imagePath);
            //pic.ImageLocation = imagePath;
            //pic.Name = "pic" + count;
            //pic.Height = 128;
            //pic.Width = 128;
            //pic.SizeMode = PictureBoxSizeMode.StretchImage;

            //pic.Location = count == 1 ? new Point(point.X, point.Y) : new Point(point.X, point.Y + 140);
            //pic.Click += img_Click;
            //panel1.Controls.Add(pic);
            //point = new Point(pic.Location.X, pic.Location.Y);
        }
        private void img_Click(object sender, EventArgs e)
        {
            var data = (PictureBox)sender;
            MessageBox.Show(data.ImageLocation);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseData();
        }
        private void CaptureCam_Load(object sender, EventArgs e)
        {
            _face = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
            _eye = new HaarCascade("haarcascade_eye.xml");
        }
        private void zoomin_Click(object sender, EventArgs e)
        {
            //CamImageBox. = ++zoom;
        }
        private void zoomout_Click(object sender, EventArgs e)
        {

        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            var c = new Choose();
            c.Show();
        }
        private byte[] ImageCompressions(Image img)
        {
            var bmp = new Bitmap(img);
            var memory = new MemoryStream();
            bmp.Save(memory, ImageFormat.Jpeg);
            var imgBytes = memory.ToArray();
            return imgBytes;
        }
        private Image ImageDecompress(byte[] imgByte)
        {
            try
            {
                var stream = new MemoryStream(imgByte);
                var img = Image.FromStream(stream);
                return img;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                registerForm rForm = new registerForm();
                rForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayUserWiseImage rForm = new DisplayUserWiseImage();
                rForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void FrameGrabber_Parrellel(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            _imageFrame = _capture.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            //Clear_Faces_Found();

            if (_imageFrame != null)
            {
                var gray_frame = _imageFrame.Convert<Gray, Byte>();
                //Face Detector
                Rectangle[] facesDetected = _face.DetectMultiScale(gray_frame, 1.2, 4, new Size(50, 50), Size.Empty);

                //Action for each element detected
                Parallel.For(0, facesDetected.Length, i =>
                {
                    try
                    {
                        facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                        facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                        facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                        facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                        var result = _imageFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        result._EqualizeHist();
                        //draw the face detected in the 0th (gray) channel with blue color
                        _imageFrame.Draw(facesDetected[i], new Bgr(Color.BlanchedAlmond), 2);
                        /*string name = _recognizer.recognize(result);
                        Console.WriteLine(name);
                        int match_value = (int)_recognizer.Get_Eigen_Distance;
                        Console.WriteLine(match_value);
                        //Draw the label for each face detected and recognized
                        _imageFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                        //ADD_Face_Found(result, name, match_value);
                         */


                        if (trainingImages.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                            //Eigen face recognizer
                            EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                               trainingImages.ToArray(),
                               labels.ToArray(),
                               5000,
                               ref termCrit);

                            name = recognizer.Recognize(result);

                            Console.WriteLine(name + " Detected");
                            //Draw the label for each face detected and recognized
                            _imageFrame.Draw(name, ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.BlanchedAlmond));

                        }



                    }
                    catch (Exception ex)
                    {
                        //do nothing as parrellel loop buggy
                        //No action as the error is useless, it is simply an error in 
                        //no data being there to process and this occurss sporadically 
                    }
                });
                //Show the faces procesed and recognized
                CamImageBox.Image = _imageFrame;
            }
        }
    }
}
