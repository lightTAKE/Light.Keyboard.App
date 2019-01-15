using System;
using System.Collections.Generic;
using System.Linq;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App.Core
{
    public class KeyMap : IKeyMap
    {
        public List<Key> Keys { get; private set; }

        public KeyMap()
        {
            Keys = new List<Key>
            {
                new Key(KeyNames.ESC, 0, 0),
                new Key(KeyNames.F1, 1, 0),
                new Key(KeyNames.F2, 2, 0),
                new Key(KeyNames.F3, 3, 0),
                new Key(KeyNames.F4, 4, 0),
                new Key(KeyNames.F5, 5, 0),
                new Key(KeyNames.F6, 6, 0),
                new Key(KeyNames.F7, 7, 0),
                new Key(KeyNames.F8, 8, 0),
                new Key(KeyNames.F9, 9, 0),
                new Key(KeyNames.F10, 10, 0),
                new Key(KeyNames.F11, 11, 0),
                new Key(KeyNames.F12, 12, 0),
                new Key(KeyNames.PRINT_SCREEN, 13, 0),
                new Key(KeyNames.SCROLL_LOCK, 14, 0),
                new Key(KeyNames.PAUSE_BREAK, 15, 0),

                new Key(KeyNames.TILDE, 0, 1),
                new Key(KeyNames.ONE, 1, 1),
                new Key(KeyNames.TWO, 2, 1),
                new Key(KeyNames.THREE, 3, 1),
                new Key(KeyNames.FOUR, 4, 1),
                new Key(KeyNames.FIVE, 5, 1),
                new Key(KeyNames.SIX, 6, 1),
                new Key(KeyNames.SEVEN, 7, 1),
                new Key(KeyNames.EIGHT, 8, 1),
                new Key(KeyNames.NINE, 9, 1),
                new Key(KeyNames.ZERO, 10, 1),
                new Key(KeyNames.MINUS, 11, 1),
                new Key(KeyNames.EQUALS, 12, 1),
                new Key(KeyNames.BACKSPACE, 13, 1),
                new Key(KeyNames.INSERT, 14, 1),
                new Key(KeyNames.HOME, 15, 1),
                new Key(KeyNames.PAGE_UP, 16, 1),
                new Key(KeyNames.NUM_LOCK, 17, 1),
                new Key(KeyNames.NUM_SLASH, 18, 1),
                new Key(KeyNames.NUM_ASTERISK, 19, 1),
                new Key(KeyNames.NUM_MINUS, 20, 1),

                new Key(KeyNames.TAB, 0, 2),
                new Key(KeyNames.Q, 1, 2),
                new Key(KeyNames.W, 2, 2),
                new Key(KeyNames.E, 3, 2),
                new Key(KeyNames.R, 4, 2),
                new Key(KeyNames.T, 5, 2),
                new Key(KeyNames.Y, 6, 2),
                new Key(KeyNames.U, 7, 2),
                new Key(KeyNames.I, 8, 2),
                new Key(KeyNames.O, 9, 2),
                new Key(KeyNames.P, 10, 2),
                new Key(KeyNames.OPEN_BRACKET, 11, 2),
                new Key(KeyNames.CLOSE_BRACKET, 12, 2),
                new Key(KeyNames.ENTER, 13, 2),
                new Key(KeyNames.KEYBOARD_DELETE, 14, 2),
                new Key(KeyNames.END, 15, 2),
                new Key(KeyNames.PAGE_DOWN, 16, 2),
                new Key(KeyNames.NUM_SEVEN, 17, 2),
                new Key(KeyNames.NUM_EIGHT, 18, 2),
                new Key(KeyNames.NUM_NINE, 19, 2),
                new Key(KeyNames.NUM_PLUS, 20, 2),

                new Key(KeyNames.CAPS_LOCK, 0, 3),
                new Key(KeyNames.A, 1, 3),
                new Key(KeyNames.S, 2, 3),
                new Key(KeyNames.D, 3, 3),
                new Key(KeyNames.F, 4, 3),
                new Key(KeyNames.G, 5, 3),
                new Key(KeyNames.H, 6, 3),
                new Key(KeyNames.J, 7, 3),
                new Key(KeyNames.K, 8, 3),
                new Key(KeyNames.L, 9, 3),
                new Key(KeyNames.SEMICOLON, 10, 3),
                new Key(KeyNames.APOSTROPHE, 11, 3),
                new Key(KeyNames.BACKSLASH, 12, 3),
                new Key(KeyNames.NUM_FOUR, 17, 3),
                new Key(KeyNames.NUM_FIVE, 18, 3),
                new Key(KeyNames.NUM_SIX, 19, 3),

                new Key(KeyNames.LEFT_SHIFT, 0, 4),
                new Key(KeyNames.Z, 1, 4),
                new Key(KeyNames.X, 2, 4),
                new Key(KeyNames.C, 3, 4),
                new Key(KeyNames.V, 4, 4),
                new Key(KeyNames.B, 5, 4),
                new Key(KeyNames.N, 6, 4),
                new Key(KeyNames.M, 7, 4),
                new Key(KeyNames.COMMA, 8, 4),
                new Key(KeyNames.PERIOD, 9, 4),
                new Key(KeyNames.FORWARD_SLASH, 10, 4),
                new Key(KeyNames.RIGHT_SHIFT, 11, 4),
                new Key(KeyNames.ARROW_UP, 13, 4),
                new Key(KeyNames.NUM_ONE, 17, 4),
                new Key(KeyNames.NUM_TWO, 18, 4),
                new Key(KeyNames.NUM_THREE, 19, 4),
                new Key(KeyNames.NUM_ENTER, 20, 4),

                new Key(KeyNames.LEFT_CONTROL, 0, 5),
                new Key(KeyNames.LEFT_WINDOWS, 1, 5),
                new Key(KeyNames.LEFT_ALT, 2, 5),
                new Key(KeyNames.SPACE, 6, 5),
                new Key(KeyNames.RIGHT_ALT, 10, 5),
                new Key(KeyNames.RIGHT_WINDOWS, 11, 5),
                new Key(KeyNames.APPLICATION_SELECT, 12, 5),
                new Key(KeyNames.RIGHT_CONTROL, 13, 5),
                new Key(KeyNames.ARROW_LEFT, 14, 5),
                new Key(KeyNames.ARROW_DOWN, 15, 5),
                new Key(KeyNames.ARROW_RIGHT, 16, 5),
                new Key(KeyNames.NUM_ZERO, 17, 5),
                new Key(KeyNames.NUM_PERIOD, 18, 5)
            };
        }

        public Key GetKey(VirtualKeys virtualKey)
        {
            Enum.TryParse(virtualKey.ToString(), out KeyNames logitechKey);
            var key = Keys.First(k => k.Name == logitechKey);
            return key;
        }
    }
}