using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 位置结构
    /// </summary>
    public struct XPoint
    {
        private Int32 m_x;
        private Int32 m_y;

        public XPoint(Int32 x, Int32 y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        public int X { get => m_x; set => m_x = value; }
        public int Y { get => m_y; set => m_y = value; }

        public static Boolean operator ==(XPoint p1, XPoint p2)
        {
            return (p1.X == p2.X) && (p1.Y == p2.Y);
        }

        public static Boolean operator !=(XPoint p1, XPoint p2)
        {
            return (p1.X != p2.X) || (p1.Y != p2.Y);
        }

        public override bool Equals(object obj)
        {
            return this == (XPoint)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static XPoint operator +(XPoint p1, XPoint p2)
        {
            return new XPoint((p1.X + p2.X), (p1.Y + p2.Y));
        }

        public static XPoint operator -(XPoint p1, XPoint p2)
        {
            return new XPoint((p1.X - p2.X), (p1.Y - p2.Y));
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", m_x, m_y);
        }
    }

    class XGraphics
    {

    }
}
