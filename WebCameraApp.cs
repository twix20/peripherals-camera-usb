using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using APIDelegate;

namespace MyCamera
{
    using APIDelegate;

    public partial class WebCameraApp : Form
    {
        private int previewHandle;
        private bool isRecording = false;
        delegate void CapturePhotoCallback();
        Thread wwwStreamThread;

        public WebCameraApp()
        {
            isRecording = false;
            InitializeComponent();
        }

        public ArrayList getListOfDevices()
        {
            ArrayList devices = new ArrayList();
            bool foundAllDevices = false;

            for(int i = 0; i < 9 && !foundAllDevices; i++)
            {
                string name = String.Empty.PadRight(100);
                string version = String.Empty.PadRight(100);

                foundAllDevices = APIDelegate.capGetDriverDescription((short)i, ref name, 100, ref version, 100);
                devices.Add(name);
            }

            return devices;
        }

        private void WebCameraApp_Load(object sender, EventArgs e)
        {
            // Init the list of capture devices
            foreach(string device in getListOfDevices())
            {
                cbDevices.Items.Add(device);
            }
        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDeviceIndex = cbDevices.SelectedIndex;
            IntPtr pbViewHandle = pbView.Handle;

            APIDelegate.DestroyWindow(previewHandle);

            previewHandle = APIDelegate.capCreateCaptureWindow("Test", APIDelegate.WS_VISIBLE | APIDelegate.WS_CHILD, 0, 0, 640, 480, pbViewHandle.ToInt32(), 0);

            if (APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_DRIVER_CONNECT, selectedDeviceIndex, null) != 0)
            {
                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SET_SCALE, 1, null);
                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SET_PREVIEWRATE, 30, null);
                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SET_PREVIEW, 1, null);

                APIDelegate.SetWindowPos(previewHandle, APIDelegate.HWND_BOTTOM, 0, 0, pbView.Height, pbView.Width, APIDelegate.SWP_NOMOVE | APIDelegate.SWP_NOZORDER);
            }
        }

        private void disconnect()
        {
            if(wwwStreamThread != null)
                wwwStreamThread.Abort(); 

            APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_DRIVER_DISCONNECT, cbDevices.SelectedIndex, null);
            APIDelegate.DestroyWindow(previewHandle);
        }

        private void WebCameraApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnect();
        }

        private void btnVideoFormat_Click(object sender, EventArgs e)
        {
            APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_DLG_VIDEOFORMAT, cbDevices.SelectedIndex, null);
        }

        private void btnVideoSource_Click(object sender, EventArgs e)
        {
            APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_DLG_VIDEOSOURCE, cbDevices.SelectedIndex, null);
        }

        private void btnVideoCapture_Click(object sender, EventArgs e)
        {
            if(isRecording)
            {
                Console.WriteLine("Stopped recording");

                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_FILE_SAVEAS, cbDevices.SelectedIndex, "video.avi");
                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_STOP, cbDevices.SelectedIndex, null);

                isRecording = false;
            } else
            {
                Console.WriteLine("Started recording");

                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_FILE_SET_CAPTURE_FILE, cbDevices.SelectedIndex, "video.avi");
                APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SEQUENCE, cbDevices.SelectedIndex, null);

                isRecording = true;
            }
        }

        private void btnCapturePhoto_Click(object sender, EventArgs e)
        {
            APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SAVEDIB, cbDevices.SelectedIndex, "picture.jpg");
        }

        private void btnWww_Click(object sender, EventArgs e)
        {
            if(wwwStreamThread == null)
            {
                wwwStreamThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    while (true)
                    {
                        CapturePhotoCallback d = new CapturePhotoCallback(() =>
                        {
                            APIDelegate.SendMessage(previewHandle, APIDelegate.WM_CAP_SAVEDIB, cbDevices.SelectedIndex, "www.jpg");
                        });
                        this.Invoke(d);
                        Thread.Sleep(30);
                    }

                });
                wwwStreamThread.Start();
            }
            else
            {
                wwwStreamThread.Abort();
                wwwStreamThread = null;
            }
        }
    }
}
