using System;

namespace Light.Keyboard.App.Core
{
    public class RandomColor : Color
    {
        public RandomColor()
        {
            var random = new Random();
            Red = random.Next(0, 100);
            Green = random.Next(0, 100);
            Blue = random.Next(0, 100);
        }
    }
}