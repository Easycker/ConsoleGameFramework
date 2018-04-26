using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public sealed class XKeyboardEventArgs : EventArgs
    {
        private XKeys m_xKeys;

        public XKeyboardEventArgs(XKeys xKeys)
        {
            this.m_xKeys = xKeys;
        }

        public XKeys GetKey()
        {
            return m_xKeys;
        }
    }
}
