using System;
using System.Drawing;
using System.Windows.Forms;
using motion;
using VideoSource;

namespace myWebCam
{
    public partial class MainFRM : Form
    {
        Camera camera = null;

        public MainFRM()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
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
            // set busy cursor
            //this.Cursor = Cursors.WaitCursor;

            // create camera
            camera = new Camera(source);
            // start camera
            camera.Start();
            camera.NewFrame += new EventHandler(camera_NewFrame);

            //this.Cursor = Cursors.Default;
        }

        void camera_NewFrame(object sender, EventArgs e)
        {
            Invalidate();

            if (camera != null)
            {
                try
                {
                    camera.Lock();
                    pictureBox1.BackgroundImage = camera.LastFrame;
                    SetControlTextValue(LBL_IMAGE_SIZE, camera.LastFrame.Width.ToString());
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (camera != null)
                camera.Stop();
        }

        delegate void SetControlTextHandler(Control ctrl, string value);
        private void SetControlTextValue(Control ctrl, string value)
        {
            if (ctrl.InvokeRequired)
                ctrl.BeginInvoke(new SetControlTextHandler(SetControlTextValue), ctrl, value);
            else
                ctrl.Text = value;
        }
    }
}