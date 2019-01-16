using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Light.Keyboard.App.Core;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviors
{
    public class RippleBehaviour : KeyboardBehaviour
    {
        private readonly Color _color;
        private readonly Color _rippleColor1;
        private readonly Color _rippleColor2;
        private readonly ManhattanDistance _manhattanDistance;

        public RippleBehaviour()
        {
            _manhattanDistance = new ManhattanDistance();
            _color = new Color(100, 100, 100);
            _rippleColor1 = new Color(25, 0, 0);
            _rippleColor2 = new Color(100, 0, 0);
            LogitechGSDK.LogiLedSetLighting(_color.Red, _color.Green, _color.Blue);
        }

        public override async void OnKeyPress(IntPtr wParam, IntPtr lParam)
        {
            base.OnKeyPress(wParam, lParam);

            var manhattanKeys = _manhattanDistance.GetManhattanDistances(PressedKey, KeyMap.Keys).ToList();

            var maxDistance = manhattanKeys.Max(m => m.Distance);
            for (var i = 0; i <= maxDistance + 1; i++)
            {
                React(manhattanKeys, i - 1, _color);
                React(manhattanKeys, i, _rippleColor1);
                React(manhattanKeys, i + 1, _rippleColor2);
                await Task.Delay(50);
            }
        }

        private void React(IEnumerable<ManhattanKey> manhattanKeys, int distance, Color color)
        {
            var keys = manhattanKeys.Where(m => m.Distance == distance);
            foreach (var key in keys)
            {
                LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(key.Name, color.Red, color.Green, color.Blue);
            }
        }
    }
}