using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCamera
{
    public class Camera : IDisposable
    {
        public int DeviceId { get; private set; }
        public int PreviewHandle { get; set; }

        public bool IsRecording { get; set; }

        public Camera(int id)
        {
            DeviceId = id;
        }

        public int CreatePreviewHanlde(IntPtr pbViewHandle, int height, int width)
        {
            PreviewHandle = APIDelegate.capCreateCaptureWindow("Test", APIDelegate.WS_VISIBLE | APIDelegate.WS_CHILD, 0, 0, height, width, pbViewHandle.ToInt32(), 0);
            if (APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_DRIVER_CONNECT, DeviceId, null) != 0)
            {
                APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_SET_SCALE, 1, null);
                APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_SET_PREVIEWRATE, 30, null);
                APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_SET_PREVIEW, 1, null);

                APIDelegate.SetWindowPos(PreviewHandle, APIDelegate.HWND_BOTTOM, 0, 0, height, width, APIDelegate.SWP_NOMOVE | APIDelegate.SWP_NOZORDER);
            }

            return PreviewHandle;
        }

        public void ShowVideoFormat()
        {
            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_DLG_VIDEOFORMAT, this.DeviceId, null);
        }
        public void ShowVideoSource()
        {
            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_DLG_VIDEOSOURCE, this.DeviceId, null);
        }

        public void StartRecordingVideo(string fileName)
        {
            Console.WriteLine("Started recording");

            IsRecording = true;

            Task.Factory.StartNew(() =>
            {
                APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_FILE_SET_CAPTURE_FILE, this.DeviceId, fileName);
            }, TaskCreationOptions.LongRunning);
        }
        public void StopRecordingVideo(string fileName)
        {
            Console.WriteLine("Stopped recording");
            IsRecording = false;

            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_FILE_SAVEAS, this.DeviceId, fileName);
            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_STOP, this.DeviceId, null);
        }

        public void CapturePhoto(string fileName)
        {
            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_SAVEDIB, this.DeviceId, fileName);
        }

        public void Dispose()
        {
            APIDelegate.SendMessage(PreviewHandle, APIDelegate.WM_CAP_DRIVER_DISCONNECT, this.DeviceId, null);
            APIDelegate.DestroyWindow(PreviewHandle);
        }
    }
}
