using System.Windows.Forms;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.KeyboardBehaviours
{
    public interface IKeyboardBehaviour
    {
        void OnKeyPress(KeyNames key);
    }
}