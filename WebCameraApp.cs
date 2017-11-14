using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyCamera
{
    using System.Timers;

    public partial class WebCameraApp : Form
    {
        const string VIDEO_FILE_NAME = "video.avi";
        const string PHOTO_FILE_NAME = "picture.jpg";
        const string STREAM_PHOTO_FILE_NAME = "www.jpg";

        Timer wwwStreamTimer;
        Camera camera;

        public WebCameraApp()
        {
            InitializeComponent();
        }

        private void WebCameraApp_Load(object sender, EventArgs e)
        {
            // Init the list of capture devices
            var devices = _getListOfDevices();
            cbDevices.DataSource = devices;

            // Init stream timer
            wwwStreamTimer = new System.Timers.Timer { Interval = 30 };
            wwwStreamTimer.Elapsed += (s, ev) =>
            {
                this.Invoke((MethodInvoker)(() =>
                    camera.CapturePhoto(STREAM_PHOTO_FILE_NAME)
                ));
            };
        }

        private void WebCameraApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            wwwStreamTimer.Dispose();
            camera.Dispose();
        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDeviceIndex = cbDevices.SelectedIndex;
            IntPtr pbViewHandle = pbView.Handle;

            if (camera != null)
                APIDelegate.DestroyWindow(camera.PreviewHandle);

            camera = new Camera(selectedDeviceIndex);
            camera.CreatePreviewHanlde(pbViewHandle, 640, 480);
        }

        private IEnumerable<string> _getListOfDevices()
        {
            var devices = new List<string>();
            bool foundAllDevices = false;

            for (int i = 0; i < 9 && !foundAllDevices; i++)
            {
                string name = String.Empty.PadRight(100);
                string version = String.Empty.PadRight(100);

                foundAllDevices = APIDelegate.capGetDriverDescription((short)i, ref name, 100, ref version, 100);
                devices.Add(name);
            }

            return devices;
        }

        private void btnVideoFormat_Click(object sender, EventArgs e)
        {
            camera.ShowVideoFormat();
        }
        private void btnVideoSource_Click(object sender, EventArgs e)
        {
            camera.ShowVideoSource();
        }
        private void btnCapturePhoto_Click(object sender, EventArgs e)
        {
            camera.CapturePhoto(PHOTO_FILE_NAME);
        }
        private void btnVideoCapture_Click(object sender, EventArgs e)
        {
            if (camera.IsRecording)
                camera.StopRecordingVideo(VIDEO_FILE_NAME);
            else
                camera.StartRecordingVideo(VIDEO_FILE_NAME);

            btnVideoCapture.BackColor = camera.IsRecording ? Color.Green : Color.Red;
        }
        private void btnWww_Click(object sender, EventArgs e)
        {
            if (wwwStreamTimer.Enabled)
            {
                Console.WriteLine("Stopped streaming");
                wwwStreamTimer.Stop();
            }
            else
            {
                Console.WriteLine("Started streaming");
                wwwStreamTimer.Start();
            }

            btnWww.BackColor = wwwStreamTimer.Enabled ? Color.Green : Color.Red;
        }
    }
}
