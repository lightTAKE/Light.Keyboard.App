using System;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviours
{
    public class RandomLightsOnKeyPress : IKeyboardBehaviour
    {
        public RandomLightsOnKeyPress()
        {
            if (!LogitechGSDK.LogiLedInitWithName("Random Lights"))
            {
                throw new Exception("Failed to initialize logitech SDK.");
            }
        }

        public void OnKeyPress(KeyNames key)
        {
            var random = new Random();
            var red = random.Next(0, 100);
            var green = random.Next(0, 100);
            var blue = random.Next(0, 100);

            LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(key, red, green, blue);
        }
    }
}