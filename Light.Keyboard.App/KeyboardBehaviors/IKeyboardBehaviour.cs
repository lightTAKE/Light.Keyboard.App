using System;

namespace Light.Keyboard.App.KeyboardBehaviors
{
    public interface IKeyboardBehaviour
    {
         void OnKeyPress(IntPtr wParam, IntPtr lParam);
    }
}