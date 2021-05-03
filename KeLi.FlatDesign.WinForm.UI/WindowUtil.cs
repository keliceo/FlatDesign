using System;
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
    }
}