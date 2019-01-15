using System;
using System.Runtime.InteropServices;
using Light.Keyboard.App.Core;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviors
{
    public abstract class KeyboardBehaviour : IKeyboardBehaviour
    {
        protected KeyMap KeyMap;
        protected Key PressedKey;

        protected KeyboardBehaviour()
        {
            if (!LogitechGSDK.LogiLedInitWithName("Light Keyboard App"))
            {
                throw new Exception("Failed to initialize Logitech SDK.");
            }

            KeyMap = new KeyMap();
        }

        public virtual void OnKeyPress(IntPtr wParam, IntPtr lParam)
        {
            var pressedKey = Marshal.ReadInt32(lParam);
            var virtualKey = (VirtualKeys)pressedKey;
            PressedKey = KeyMap.GetKey(virtualKey);
        }
    }
}