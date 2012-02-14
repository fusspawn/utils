using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WurmUtils.InputTools
{
    public class ScreenShotManager
    {
        private static Bitmap CurrentScreenShot = null;
        public static Bitmap TakescreenShot()
        {
            if (CurrentScreenShot == null) {
                GetScreenShot(InputManager.GetWindow());
            }

            return CurrentScreenShot;
        }
        private static void GetScreenShot(System.IntPtr intPtr)
        {

            if (CurrentScreenShot != null)
                return;

            ScreenCapturer Capture = new ScreenCapturer();
            CurrentScreenShot = Capture.Capture(intPtr, enmScreenCaptureMode.Window);
            CurrentScreenShot.Save("./screenshot.png", ImageFormat.Png);
            Console.WriteLine("Saved: ./screenshot.png");
        }
        public static void ResetFrame()
        {
            CurrentScreenShot = null;
        }
        public static Color GetScreenColor(int x, int y) 
        {

            if (CurrentScreenShot == null)
                GetScreenShot(InputManager.GetWindow());

            return CurrentScreenShot.GetPixel(x, y);
        }
    }

    public enum enmScreenCaptureMode
    {
        Screen,
        Window
    }

    class ScreenCapturer
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public Bitmap Capture(IntPtr Handle, enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window)
        {
            Rectangle bounds;
            var rect = new Rect();
            GetWindowRect(Handle, ref rect);
            bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            CursorPosition = new System.Drawing.Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(result))
            {
                g.CopyFromScreen(new System.Drawing.Point(bounds.Left, bounds.Top), System.Drawing.Point.Empty, bounds.Size);
            }

            return result;
        }

        public System.Drawing.Point CursorPosition
        {
            get;
            protected set;
        }
    }

}
