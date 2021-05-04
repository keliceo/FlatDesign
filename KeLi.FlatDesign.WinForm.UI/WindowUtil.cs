using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KeLi.FlatDesign.WinForm.UI
{
    public static class WindowUtil
    {
        private const int HTCAPTION = 2;

        private const int WM_NCLBUTTONDOWN = 0x00A1;

        public static void MoveWindow(this IntPtr handle)
        {
            User32Importer.ReleaseCapture();

            var control = Control.FromHandle(handle);

            if (control is Form)
                control.Handle.SendMessage(WM_NCLBUTTONDOWN, HTCAPTION, 0);

            else
                control.FindForm()?.Handle.SendMessage(WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        public static Size GetWorkingAreaSize(this Control control)
        {
            if (control is null)
                throw new ArgumentNullException(nameof(control));

            if (control.IsDisposed)
                throw new InvalidDataException(nameof(control));

            var rect = Screen.GetWorkingArea(control);

            return new Size(rect.Width, rect.Height);
        }
    }
}