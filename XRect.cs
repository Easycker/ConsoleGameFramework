using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static ConsoleGameFramework.XGraphics;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 矩形结构
    /// </summary>
    public struct XRect
    {
        /// <summary>
        /// 矩形左上角横坐标
        /// </summary>
        private Int32 m_x;
        /// <summary>
        /// 矩形左上角纵坐标
        /// </summary>
        private Int32 m_y;
        /// <summary>
        /// 矩形宽度
        /// </summary>
        private Int32 m_width;
        /// <summary>
        /// 矩形高度
        /// </summary>
        private Int32 m_height;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public XRect(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();

            this.m_x = x;
            this.m_y = y;
            this.m_width = width;
            this.m_height = height;
        }

        public XRect(XPoint point, Int32 width, Int32 height)
        {
            this.m_x = point.X;
            this.m_y = point.Y;
            this.m_width = width;
            this.m_height = height; 
        }

        public XRect(Int32 x, Int32 y, XSize size)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_width = size.GetWidth();
            this.m_height = size.GetHeight();
        }

        public XRect(XPoint point, XSize size)
        {
            this.m_x = point.X;
            this.m_y = point.Y;
            this.m_width = size.GetWidth();
            this.m_height = size.GetHeight();
        }

        /// <summary>  
        /// 获取矩形左上角的横坐标
        /// </summary>  
        /// <returns></returns>  
        public Int32 GetX()
        {
            return this.m_x;
        }
        /// <summary>  
        /// 获取矩形左上角的纵坐标
        /// </summary>  
        /// <returns></returns>  
        public Int32 GetY()
        {
            return this.m_y;
        }
        /// <summary>
        /// 获取矩形宽度
        /// </summary>
        /// <returns></returns>
        public Int32 GetWidth()
        {
            return this.m_width;
        }
        /// <summary>  
        /// 获取矩形高度  
        /// </summary>  
        /// <returns></returns>  
        public Int32 GetHeight()
        {
            return this.m_height;
        }
        /// <summary>  
        /// 获取矩形  
        /// </summary>  
        /// <returns></returns>  
        public XRect GetXRect()
        {
            return new XRect(this.m_x, this.m_y, this.m_width, this.m_height);
        }

        /// <summary>  
        /// 设置矩形左上角的横坐标
        /// </summary>  
        /// <param name="x"></param>  
        public void SetX(Int32 x)
        {
            this.m_x = x;
        }
        /// <summary>  
        /// 设置矩形左上角的纵坐标
        /// </summary>  
        /// <param name="y"></param>  
        public void SetY(Int32 y)
        {
            this.m_y = y;
        }
        /// <summary>  
        /// 设置矩形宽度  
        /// </summary>  
        /// <param name="w"></param>  
        public void SetWidth(Int32 w)
        {
            if (w <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_width = w;
        }
        /// <summary>  
        /// 设置矩形高度  
        /// </summary>  
        /// <param name="h"></param>  
        public void SetHeight(Int32 h)
        {
            if (h <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_height = h;
        }
        /// <summary>  
        /// 设置矩形  
        /// </summary>  
        /// <param name="x"></param>  
        /// <param name="y"></param>  
        /// <param name="w"></param>  
        /// <param name="h"></param>  
        public void SetXRect(Int32 x, Int32 y, Int32 w, Int32 h)
        {
            if (w <= 0 || h <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_x = x;
            this.m_y = y;
            this.m_width = w;
            this.m_height = h;
        }

        /// <summary>
        /// 矩形的缩放
        /// </summary>
        /// <param name="flateX"></param>
        /// <param name="flateY"></param>
        public void Inflate(Int32 flateX, Int32 flateY)
        {
            this.m_x -= flateX;
            this.m_y -= flateY;
            this.m_width  += flateX << 1;
            this.m_height += flateY << 1;
        }

        /// <summary>
        /// 矩形的调整（位置和尺寸）
        /// </summary>
        /// <param name="rect"></param>
        public void Adjust(ref XRect rect)
        {
            Int32 max_x = Console.WindowWidth >> 1;
            Int32 max_y = Console.WindowHeight;

            if (rect.m_x < 0)
            {
                rect.m_x = 0;
            }
            else if (rect.m_x > max_x)
            {
                rect.m_x = max_x - 1;
            }

            if (rect.m_y < 0)
            {
                rect.m_y = 0;
            }
            else if (rect.m_y > max_y)
            {
                rect.m_y = max_y;
            }

            rect.m_x += rect.m_x;
        }

        /// <summary>
        /// 判断两个矩形是否相交
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public Boolean CollisionWith(XRect rect)
        {
            return (m_x <= rect.GetX() && rect.GetX() <= (m_x + m_width) &&
                    m_y <= rect.GetY() && rect.GetY() <= (m_y + m_height));
        }

        public override string ToString()
        {
            return String.Format("[{0},{1},{2},{3}]", m_x, m_y, m_width, m_height);
        }
    }
}
