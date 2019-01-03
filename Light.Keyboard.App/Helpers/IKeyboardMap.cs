using System.Collections.Generic;
using System.Windows.Forms;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.Helpers
{
    public interface IKeyboardMap
    {
        KeyNames GetKey(Keys keyCode);

        IEnumerable<KeyNames> GetKeyNeighbour(Keys keyCode);
    }
}