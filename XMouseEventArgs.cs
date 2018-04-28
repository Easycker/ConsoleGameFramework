using System;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 鼠标事件参数
    /// </summary>
    public sealed class XMouseEventArgs : EventArgs
    {
        private Int32 m_x;
        private Int32 m_y;
        private Boolean m_leave;
        private XMouseButtons m_vKey;

        public XMouseEventArgs(Int32 x, Int32 y, Boolean leave)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_leave = leave;
        }

        public XMouseEventArgs(Int32 x, Int32 y, XMouseButtons key)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_vKey = key;
        }

        public Int32 GetX()
        {
            return m_x;
        }

        public Int32 GetY()
        {
            return m_y;
        }

        public Boolean isLeave()
        {
            return m_leave;
        }

        public XMouseButtons GetKey()
        {
            return m_vKey;
        }

        public bool ContainsKey(XMouseButtons key)
        {
            return (GetKey() & key) == key;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", GetX(), GetY());
        }
    }
}
