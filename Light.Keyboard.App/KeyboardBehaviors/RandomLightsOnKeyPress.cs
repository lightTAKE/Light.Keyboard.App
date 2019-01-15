using System;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviors
{
    public class RandomLightsOnKeyPress : KeyboardBehaviour
    {
        public override void OnKeyPress(IntPtr wParam, IntPtr lParam)
        {
            base.OnKeyPress(wParam, lParam);

            var random = new Random();
            var red = random.Next(0, 100);
            var green = random.Next(0, 100);
            var blue = random.Next(0, 100);

            LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(PressedKey.Name, red, green, blue);
        }
    }
}