using System;
using System.Drawing;
using System.Windows.Forms;
using ASSISTME.SNIPS;
using ASSISTME.SNIPS.IMG.FILTERS;
using motion;
using VideoSource;

namespace ARScratch
{
    public partial class ARView : Form
    {       
        private static MyImg img;
        Camera camera = null;
        private static Bitmap bmp;
        private static Graphics g;
        public ARView()
        {
            InitializeComponent();
            bmp = new Bitmap(320,240);
            g = Graphics.FromImage(bmp);
        }

        public void InitializeVideo()
        {
            CaptureDeviceForm form = new CaptureDeviceForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                CaptureDevice localSource = new CaptureDevice();
                localSource.VideoSource = form.Device;

                // open it
                OpenVideoSource(localSource);
            }
        }

        private void OpenVideoSource(IVideoSource source)
        {            
            // create camera
            camera = new Camera(source);
            // start camera
            camera.Start();
            camera.NewFrame += new EventHandler(camera_NewFrame);

        }

        void camera_NewFrame(object sender, EventArgs e)
        {
            Invalidate();

            if (camera != null)
            {
                try
                {
                    camera.Lock();
                    img = new MyImg(camera.LastFrame);
                    g.DrawImage(img.Image, 0, 0, 320, 240);
                    img = new MyImg(bmp);
                    Booster.Execute(img);
                    PCT_BOX.Image = img.Image;
                }
                catch (Exception)
                {
                }
                finally
                {
                    camera.Unlock();
                }
            }
        }

        private void BTN_OPEN_Click(object sender, EventArgs e)
        {
            OpenImageFile();
        }
        
        private void BTN_EXECUTE_Click(object sender, EventArgs e)
        {
            InitializeVideo();
        }

        private void OpenImageFile()
        {
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    //bmp = new Bitmap(OFD.FileName);
                    img = new MyImg(new Bitmap(OFD.FileName));
                    PCT_BOX.Image = img.Image;
                }
                catch (Exception) { }
            }
        }

        private void ExecuteBoost()
        {
            Booster.Execute(img);
            PCT_BOX.Refresh();
        }

        private void ARView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(camera != null)
                camera.Stop();
        }

        private void BTN_EXECUTE_Click_1(object sender, EventArgs e)
        {
            Booster.Execute(img);
            PCT_BOX.Refresh();
        }
    }
}
