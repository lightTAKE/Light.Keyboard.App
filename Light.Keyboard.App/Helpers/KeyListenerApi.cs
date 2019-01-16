using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Light.Keyboard.App.Helpers
{
    public class KeyListenerApi
    {
        private const string KERNEL32 = "kernel32.dll";
        private const string USER32 = "user32.dll";
        private const int LowLevelKeyboardHook = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYS_KEYDOWN = 0x104;
        private const int WM_SYS_KEYUP = 0x105;

        private static IntPtr _hook = IntPtr.Zero;
        private static HookDel _hookFunction;
        private static KeyHandler _keyHandler;

        private static int _ilParam = int.MinValue;
        private static bool _holding;

        [DllImport(USER32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookDel lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport(USER32, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport(USER32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr HookDel(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void KeyHandler(IntPtr wParam, IntPtr lParam);

        public static void CreateHook(KeyHandler keyHandler)
        {
            var currentProcess = Process.GetCurrentProcess();
            var module = currentProcess.MainModule;

            _hookFunction = HookFunction;
            _keyHandler = keyHandler;
            _hook = SetWindowsHookEx(LowLevelKeyboardHook, _hookFunction, GetModuleHandle(module.ModuleName), 0);
        }

        public static bool DestroyHook()
        {
            return UnhookWindowsHookEx(_hook);
        }

        private static IntPtr HookFunction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var iwParam = wParam.ToInt32();
            var ilParam = Marshal.ReadInt32(lParam);

            if (nCode >= 0 && (iwParam == WM_KEYDOWN || iwParam == WM_SYS_KEYDOWN) && (!_holding || _ilParam != ilParam))
            {
                _holding = true;
                _keyHandler(wParam, lParam);
            }
            else if (nCode >= 0 && (iwParam == WM_KEYUP || iwParam == WM_SYS_KEYUP))
            {
                _holding = false;
            }

            _ilParam = ilParam;
            return CallNextHookEx(_hook, nCode, wParam, lParam);
        }
    }
}