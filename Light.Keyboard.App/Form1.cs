using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.KeyboardBehaviours;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App
{
    public partial class Form1 : Form
    {
        private RandomLightsOnKeyPress _randomLights;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyListenerApi.CreateHook(KeyListener);
            _randomLights = new RandomLightsOnKeyPress();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogitechGSDK.LogiLedShutdown();
            KeyListenerApi.DestroyHook();
        }

        public void KeyListener(IntPtr wParam, IntPtr lParam)
        {
            var key = Marshal.ReadInt32(lParam);
            var virtualKey = (VirtualKeys)key;
            Console.WriteLine($"{key}; {virtualKey}");

            Enum.TryParse(virtualKey.ToString(), out KeyNames logitechKey);

            _randomLights.OnKeyPress(logitechKey);


            lblKeyPressed.Text = $"Key pressed: {key}; {virtualKey}\n";
        }
    }
}