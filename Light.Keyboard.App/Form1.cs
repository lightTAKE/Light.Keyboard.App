using System;
using System.Windows.Forms;
using Light.Keyboard.App.Helpers;
using Light.Keyboard.App.KeyboardBehaviors;
using Light.Keyboard.App.Logitech;

namespace Light.Keyboard.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var behaviour = new RippleBehaviour();
            KeyListenerApi.CreateHook(behaviour.OnKeyPress);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogitechGSDK.LogiLedShutdown();
            KeyListenerApi.DestroyHook();
        }
    }
}