using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DynamicaLabsTT.UI.Infrastructure
{
    class TextBoxTraceListener : TraceListener
    {
        private TextBox _target;
        private StringSendDelegate _invokeWrite;

        public TextBoxTraceListener(TextBox target)
        {
            _target = target;
            _invokeWrite = new StringSendDelegate(SendString);
            _target.VisibleChanged += (sender, e) =>
            {
                if (_target.Visible)
                {
                    _target.SelectionStart = _target.TextLength;
                    _target.ScrollToCaret();
                }
            };
        }

        public override void Write(string message)
        {
            _target.Invoke(_invokeWrite, new object[] { message });
        }

        public override void WriteLine(string message)
        {
            
            _target.Invoke(_invokeWrite, new object[]
                { message + Environment.NewLine });
        }

        private delegate void StringSendDelegate(string message);
        private void SendString(string message)
        { 
            _target.Text += message;
        }
    }
}
