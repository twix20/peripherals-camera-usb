using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace APIDelegate
{
    public class APIDelegate
    {
        public const short WM_CAP = 0x400;
        public const int WM_CAP_DRIVER_CONNECT = 0x40a;
        public const int WM_CAP_DRIVER_DISCONNECT = 0x40b;
        public const int WM_CAP_EDIT_COPY = 0x41e;
        public const int WM_CAP_SET_PREVIEW = 0x432;
        public const int WM_CAP_SET_OVERLAY = 0x433;
        public const int WM_CAP_SET_PREVIEWRATE = 0x434;
        public const int WM_CAP_SET_SCALE = 0x435;
        public const int WM_CAP_FILE_SET_CAPTURE_FILE = WM_CAP + 20;
        public const int WM_CAP_FILE_SAVEAS = WM_CAP + 23;
        public const int WM_CAP_SAVEDIB = WM_CAP + 25;
        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP + 42;
        public const int WM_CAP_SEQUENCE = WM_CAP + 62;
        public const int WM_CAP_STOP = WM_CAP + 68;


        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;

        public const short SWP_NOMOVE = 0x2;
        public const short SWP_NOZORDER = 0x4;

        public const short HWND_BOTTOM = 1;

        [DllImport("avicap32.dll")]
        public static extern bool capGetDriverDescription(
           short wDriverIndex,
           [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName,
           int cbName,
           [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszVer,
           int cbVer
        );

        [DllImport("avicap32.dll")]
        public static extern int capCreateCaptureWindow(
           string lpszWindowName,
           int dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           int hWnd,
           int nID
        );

        [DllImport("user32")]
        public static extern bool SetWindowPos(
          int hWnd,
          int hWndInsertAfter,
          int X,
          int Y,
          int cx,
          int cy,
          int uFlags
        );

        [DllImport("user32")]
        public static extern int SendMessage(
          int hWnd,
          int Msg,
          int wParam,
          string lParam
        );

        [DllImport("user32")]
        public static extern bool DestroyWindow(int hwnd);
    }
}