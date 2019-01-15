using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.Core
{
    public class Key
    {
        public KeyNames Name { get; protected set; }

        public KeyCoordinate Coordinate { get; protected set; }

        public Key()
        {
        }

        public Key(KeyNames key, int x, int y)
        {
            Name = key;
            Coordinate = new KeyCoordinate(x, y);
        }
    }
}