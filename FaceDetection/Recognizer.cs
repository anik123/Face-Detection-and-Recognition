using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetection
{
    public class Recognizer
    {


        #region Vaiable

        float Eigen_Distance = -1;
        string Eigen_label;
        int Eigen_threshold = 3000;
        int LBPH_threshold = 0;
        public string Recognizer_Type = "EMGU.CV.EigenFaceRecognizer";
        private List<Image<Gray, byte>> imgList = new List<Image<Gray, byte>>();
        private List<int> imgIds = new List<int>();
        private List<string> imgLabels = new List<string>();
        private FaceRecognizer recognizer;
        public bool isTrained = false;

        #endregion

        public Recognizer(List<Image<Gray, byte>> _imgList, List<int> _imgIds, List<string> _imgLabels)
        {
            imgList = _imgList;
            imgIds = _imgIds;
            imgLabels = _imgLabels;
        }

        public void loadRecognizer()
        {
            try
            {

                //Eigen face recognizer
                //Parameters:	
                //      num_components – The number of components (read: Eigenfaces) kept for this Prinicpal 
                //          Component Analysis. As a hint: There’s no rule how many components (read: Eigenfaces) 
                //          should be kept for good reconstruction capabilities. It is based on your input data, 
                //          so experiment with the number. Keeping 80 components should almost always be sufficient.
                //
                //      threshold – The threshold applied in the prediciton. This still has issues as it work inversly to LBH and Fisher Methods.
                //          if you use 0.0 recognizer.Predict will always return -1 or unknown if you use 5000 for example unknow won't be reconised.
                //          As in previous versions I ignore the built in threhold methods and allow a match to be found i.e. double.PositiveInfinity
                //          and then use the eigen distance threshold that is return to elliminate unknowns. 
                //
                //NOTE: The following causes the confusion, sinc two rules are used. 
                //--------------------------------------------------------------------------------------------------------------------------------------
                //Eigen Uses
                //          0 - X = unknown
                //          > X = Recognised
                //
                //Fisher and LBPH Use
                //          0 - X = Recognised
                //          > X = Unknown
                //
                // Where X = Threshold value



                switch (Recognizer_Type)
                {
                    case ("EMGU.CV.LBPHFaceRecognizer"):
                        recognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);//50
                        break;
                    case ("EMGU.CV.FisherFaceRecognizer"):
                        recognizer = new FisherFaceRecognizer(0, 3500);//4000
                        break;
                    case ("EMGU.CV.EigenFaceRecognizer"):
                    default:
                        recognizer = new EigenFaceRecognizer(90, double.PositiveInfinity);
                        break;
                }

                recognizer.Train(imgList.ToArray(), imgIds.ToArray());
                isTrained = true;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public float Get_Eigen_Distance
        {
            get
            {
                //get eigenDistance
                return Eigen_Distance;
            }
        }
        public string recognize(Image<Gray, byte> Input_image, int Eigen_Thresh = -1)
        {
            try
            {
                if (isTrained)
                {
                    FaceRecognizer.PredictionResult ER = recognizer.Predict(Input_image);
                    Console.WriteLine(ER.Label);
                    if (ER.Label == -1)
                    {
                        Eigen_label = "Unknown";
                        Eigen_Distance = 0;
                        return Eigen_label;
                    }
                    else
                    {
                        Eigen_label = imgLabels[ER.Label];
                        Eigen_Distance = (float)ER.Distance;
                        if (Eigen_Thresh > -1) Eigen_threshold = Eigen_Thresh;



                        //Only use the post threshold rule if we are using an Eigen Recognizer 
                        //since Fisher and LBHP threshold set during the constructor will work correctly 
                        switch (Recognizer_Type)
                        {
                            case ("EMGU.CV.EigenFaceRecognizer"):
                                if (Eigen_Distance > Eigen_threshold) return Eigen_label;
                                else return "Unknown";
                            case ("EMGU.CV.LBPHFaceRecognizer"):
                                //Note how the Eigen Distance must be below the threshold unlike as above
                                if (Eigen_Distance < LBPH_threshold) return Eigen_label;
                                else return "Unknown";
                            case ("EMGU.CV.FisherFaceRecognizer"):
                            default:
                                return Eigen_label; //the threshold set in training controls unknowns
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return "";
        }
    }
}
