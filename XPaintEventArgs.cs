using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public sealed class XPaintEventArgs : EventArgs
    {

        private XRect m_rect;
        private XDraw m_draw;

        public XPaintEventArgs(XRect rect, XDraw draw)
        {
            this.m_rect = rect;
            this.m_draw = draw;
        }

        public XRect GetClientRect()
        {
            return this.m_rect;
        }

        public void SetClientRect(XRect rect)
        {
            this.m_rect = rect;
        }

        public XDraw GetDraw()
        {
            return this.m_draw;
        }

        public void SetDraw(XDraw draw)
        {
            this.m_draw = draw;
        }
    }
}
