namespace Light.Keyboard.App.Core
{
    public class Color
    {
        public int Red { get; protected set; }

        public int Green { get; protected set; }

        public int Blue { get; protected set; }

        public Color()
        {
        }

        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}