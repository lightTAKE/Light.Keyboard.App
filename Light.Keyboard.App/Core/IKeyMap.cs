using Light.Keyboard.App.Helpers;

namespace Light.Keyboard.App.Core
{
    internal interface IKeyMap
    {
        Key GetKey(VirtualKeys virtualKey);
    }
}