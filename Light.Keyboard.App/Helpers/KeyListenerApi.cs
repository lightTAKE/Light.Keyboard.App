using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Light.Keyboard.App.Helpers
{
    public class KeyListenerApi
    {
        internal const string ADVAPI32 = "advapi32.dll";
        internal const string KERNEL32 = "kernel32.dll";
        internal const string USER32 = "user32.dll";
        internal const int LowLevelKeyboardHook = 13;

        private static IntPtr _hook = IntPtr.Zero;
        private static HookDel _hookFunction;
        private static KeyHandler _keyHandler;

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
            var currentProcces = Process.GetCurrentProcess();
            var module = currentProcces.MainModule;

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
            int iwParam = wParam.ToInt32();
            //depending on what you want to detect you can either detect keypressed or keyrealased also with  a bit tweaking keyclicked.
            if (nCode >= 0 && (iwParam == 0x100 || iwParam == 0x104)) //0x100 = WM_KEYDOWN, 0x104 = WM_SYSKEYDOWN
            {
                _keyHandler(wParam, lParam);
            }

            return CallNextHookEx(_hook, nCode, wParam, lParam);
        }
    }
}