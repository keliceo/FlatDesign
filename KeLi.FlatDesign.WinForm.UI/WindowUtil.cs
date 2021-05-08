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

        public static Size GetFullScreenSize()
        {
            var rect = Screen.PrimaryScreen.Bounds;

            return new Size(rect.Width, rect.Height);
        }

        public static void ComputeLocation(this Form current, Form parent)
        {
            if (current == null)
                throw new ArgumentNullException(nameof(current));

            if (current.IsDisposed)
                throw new ObjectDisposedException(nameof(current));

            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            if (parent.IsDisposed)
                throw new ObjectDisposedException(nameof(parent));

            current.ComputeLocation(parent.Size, parent.Location);
        }

        public static void ComputeLocation(this Form currentFrm, Size parentSize, Point parentLocation = default)
        {
            if (currentFrm == null)
                throw new ArgumentNullException(nameof(currentFrm));

            if (currentFrm.IsDisposed)
                throw new ObjectDisposedException(nameof(currentFrm));

            if (parentSize == default)
                throw new ArgumentNullException(nameof(parentSize));

            if (parentLocation == default)
                parentLocation = new Point(0, 0);

            var currentSize = currentFrm.Size;
            var spaceSize = new Size(parentSize.Width - currentSize.Width, parentSize.Height - currentSize.Height);

            currentFrm.Location = new Point(parentLocation.X + spaceSize.Width / 2, parentLocation.Y + spaceSize.Height / 2);
        }
    }
}