using Light.Keyboard.App.Core;

namespace Light.Keyboard.App.Helpers
{
    public class ManhattanKey : Key
    {
        public int Distance { get; private set; }

        public ManhattanKey(Key key, int distance)
        {
            Name = key.Name;
            Coordinate = key.Coordinate;
            Distance = distance;
        }
    }
}