using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using System.IO;

namespace WurmUtils.InputTools
{
    public class InputManager
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        static IntPtr WindowHandle;


        public static string CurrentAction = "";
        static VirtualKeyCode ActionKey = VirtualKeyCode.VK_K;
        static VirtualKeyCode RebinderKey = VirtualKeyCode.VK_I;


        /**
    * Mouse functions
    */
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern long mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 cButtons, Int32 dwExtraInfo);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern void SetCursorPos(Int32 x, Int32 y);

        public const Int32 MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const Int32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const Int32 MOUSEEVENTF_LEFTUP = 0x0004;
        public const Int32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const Int32 MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const Int32 MOUSEEVENTF_MOVE = 0x0001;
        public const Int32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const Int32 MOUSEEVENTF_RIGHTUP = 0x0010;

        public static void PerformLeftClick(Int32 x, Int32 y)  {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void PerformRightClick(Int32 x, Int32 y) {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        
        public static void SendAction(string ActionName) {
            if (CurrentAction != ActionName) {
                RebindAction(ActionName);
                InputSimulator.SimulateKeyPress(RebinderKey);
            }

            InputSimulator.SimulateKeyPress(ActionKey);
        }

        private static void RebindAction(string ActionName)
        {
            string rebind_code = "bind k " + ActionName;
            Console.WriteLine("Client Exec: " + rebind_code);
            if (File.Exists(WurmUtils.Core.Static.RebinderPath))
                File.Delete(WurmUtils.Core.Static.RebinderPath);

            TextWriter Writer = File.CreateText(WurmUtils.Core.Static.RebinderPath);
            Writer.WriteLine(rebind_code);
            Writer.Flush();
            Writer.Close();
            CurrentAction = ActionName;
        }

        public static bool SetWindow(string WindowTitle) {
            WindowHandle = FindWindow(null, WindowTitle);
            if (WindowHandle == IntPtr.Zero)
            {
                Console.WriteLine("Couldnt find Window");
                return false;
            }
            Console.WriteLine("Found Windows.");
            return true;
        }

        public static IntPtr GetWindow() {
            return WindowHandle;
        }


        public static void PressKey(VirtualKeyCode S)
        {
            if (WindowHandle == null) {
                Console.WriteLine("Cant Send Keypress to Null Window");
                return;
            }

            InputSimulator.SimulateKeyPress(S);
            Console.WriteLine("Sent Key");
        }
        public static void HoldKey(VirtualKeyCode Key, Int32 MS)
        {
            InputSimulator.SimulateKeyDown(Key);
            Thread.Sleep(MS);
            InputSimulator.SimulateKeyUp(Key);
        }
    }

    public struct Point {
        public int X;
        public int Y;
    }
}
