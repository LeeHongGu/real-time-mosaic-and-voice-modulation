using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using AudioPitchShiftNative;


namespace mosaic_modulation_project
{
    public partial class Form1 : Form
    {
        VideoCapture video;
        Mat frame = new Mat();
        voice_mod vm = new voice_mod();

        //int shift_val = 7; //음성변조 계수
        //int rate = 15; //모자이크 계수

        //com 서버 생성
        //public static Type mlType;
        //public static Object matlab;

        String filenameFaceCascade = "haarcascade_frontalface_alt.xml";
        CascadeClassifier faceCascade = new CascadeClassifier();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //mlType = Type.GetTypeFromProgID("Matlab.Application");
            //matlab = Activator.CreateInstance(mlType);

            try
            {
                video = new VideoCapture(0);
                video.FrameWidth = 640;
                video.FrameHeight = 480;
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sleepTime = (int)Math.Round(1000 / video.Fps);

            vm.realtime();

            if (!faceCascade.Load(filenameFaceCascade))
            {
                Console.WriteLine("error");
                return;
            }

            video.Read(frame);

            // detect
            Rect[] faces = faceCascade.DetectMultiScale(frame);
            Console.WriteLine(faces.Length);


            foreach (var item in faces)
            {
                //OpenCvSharp.Point lb = new OpenCvSharp.Point(item.X + item.Width, item.Y + item.Height);
                //OpenCvSharp.Point tr = new OpenCvSharp.Point(item.X, item.Y);
                Mat mosaic_frame = new Mat(frame, new Rect(item.X, item.Y, item.Width, item.Height));
                Mat temp_frame = new Mat();

                //Cv2.Resize(mosaic_frame, temp_frame, new OpenCvSharp.Size(item.Width / ((item.X+10)/10), item.Height / ((item.Y+10)/10)));
                Cv2.Resize(mosaic_frame, temp_frame, new OpenCvSharp.Size(item.Width / 15, item.Height / 15));
                Cv2.Resize(temp_frame, mosaic_frame, new OpenCvSharp.Size(item.Width, item.Height));

                //Cv2.Rectangle(frame, item, Scalar.Red, 0); // add rectangle to the image

                Console.WriteLine("faces : " + item);
            }



            // display
            pictureBoxIpl1.ImageIpl = frame;

            

            Cv2.WaitKey(sleepTime);
            video.Release();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            vm.modulation();
        }
    }
}
