using System;
using System.Threading.Tasks;
using Light.Keyboard.App.Core;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviors
{
    public class RandomColorBehaviour : KeyboardBehaviour
    {
        private readonly ManhattanDistance _manhattanDistance;

        public RandomColorBehaviour()
        {
            _manhattanDistance = new ManhattanDistance();
        }

        public override async void OnKeyPress(IntPtr wParam, IntPtr lParam)
        {
            base.OnKeyPress(wParam, lParam);

            var color = new RandomColor();

            var keys = _manhattanDistance.GetManhattanDistances(PressedKey, KeyMap.Keys);
            foreach (var key in keys)
            {
                await Task.Delay(1);
                React(key, color);
            }
        }

        private void React(Key key, Color color)
        {
            LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(key.Name, color.Red, color.Green, color.Blue);
        }
    }
}