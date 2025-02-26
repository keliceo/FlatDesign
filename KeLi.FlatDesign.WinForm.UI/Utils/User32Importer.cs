﻿using System;
using System.Runtime.InteropServices;

namespace KeLi.FlatDesign.WinForm.UI.Utils
{
    public static class User32Importer
    {
        [DllImport("user32.dll")]
        public static extern int SetClassLong(this IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetClassLong(this IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(this IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(this IntPtr hwnd, int nCmdShow);
    }
}