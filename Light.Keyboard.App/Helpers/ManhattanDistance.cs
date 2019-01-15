using System;
using System.Collections.Generic;
using System.Linq;
using Light.Keyboard.App.Core;

namespace Light.Keyboard.App.Helpers
{
    public class ManhattanDistance
    {
        public IEnumerable<ManhattanKey> GetManhattanDistances(Key pressedKey, List<Key> keys)
        {
            var manhattanMap = new List<ManhattanKey>();
            foreach (var key in keys)
            {
                var manhattanDistance = Math.Abs(pressedKey.Coordinate.X - key.Coordinate.X) + Math.Abs(pressedKey.Coordinate.Y - key.Coordinate.Y);
                var manhattanKey = new ManhattanKey(key, manhattanDistance);
                manhattanMap.Add(manhattanKey);
            }
            return manhattanMap.OrderBy(m => m.Distance);
        }
    }
}