using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 鼠标键值
    /// </summary>
    [Flags]
    public enum XMouseButtons
    {
        Left   = 0x01,
        Right  = 0x02,
        Middle = 0x04,
        None   = 0
    }

    /// <summary>
    /// 鼠标类
    /// </summary>
    internal sealed class XMouse : XInput
    {
        /// <summary>
        /// 鼠标事件委托
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="e"></param>
        internal delegate void XMouseHandler<TEventArgs>(TEventArgs e);
        
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        private event XMouseHandler<XMouseEventArgs> m_mouseMove;
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        private event XMouseHandler<XMouseEventArgs> m_mouseDown;
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        private event XMouseHandler<XMouseEventArgs> m_mouseAway;

        /// <summary>
        /// 鼠标坐标的最大 X 值
        /// </summary>
        private readonly Int32 MAX_X = 639;
        /// <summary>
        /// 鼠标坐标的最大 Y 值
        /// </summary>
        private readonly Int32 MAX_Y = 400;

        /// <summary>
        /// 控制台句柄
        /// </summary>
        private IntPtr m_hwnd = IntPtr.Zero;
        /// <summary>
        /// 鼠标是否离开屏幕范围
        /// </summary>
        private Boolean m_leave;
        /// <summary>
        /// 鼠标离开前的的位置
        /// </summary>
        private XPoint m_oldPoint;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hwnd"></param>
        public XMouse(IntPtr hwnd)
        {
            this.m_hwnd = hwnd;
            this.m_leave = false;
            this.m_oldPoint = new XPoint(0, 0);

            this.MAX_X = (Console.WindowWidth << 3) - 1;
            this.MAX_Y = Console.WindowHeight << 4;
        }

        #region 鼠标函数

        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        private Boolean isMouseDown(XMouseButtons vKey)
        {
            return 0 != (GetAsyncKeyState((Int32)vKey) & KEY_STATE);
        }

        /// <summary>
        /// 获取当前按下的鼠标按键
        /// </summary>
        /// <returns></returns>
        private XMouseButtons GetCurDownMouse()
        {
            XMouseButtons vKey = XMouseButtons.None;
            foreach (Int32 key in Enum.GetValues(typeof(XMouseButtons)))
            {
                if (isMouseDown((XMouseButtons)key))
                {
                    vKey |= (XMouseButtons)key; 
                }
            }
            return vKey;
        }

        /// <summary>
        /// 获取鼠标横坐标
        /// </summary>
        /// <returns></returns>
        private Int32 GetMouseX()
        {
            return GetMousePoint().X;
        }

        /// <summary>
        /// 获取鼠标纵坐标
        /// </summary>
        /// <returns></returns>
        private Int32 GetMouseY()
        {
            return GetMousePoint().Y;
        }

        /// 是否离开工作区
        private Boolean isLeave()
        {
            return m_leave;
        }

        /// <summary>
        /// 获取鼠标坐标
        /// </summary>
        /// <returns></returns>
        private XPoint GetMousePoint()
        {
            XPoint point;

            if (GetCursorPosition(out point)) // 获取鼠标在屏幕上的位置
            {
                if (m_hwnd != IntPtr.Zero)
                {
                    // 将屏幕坐标转换为控制台工作区坐标
                    ConvertPosition(m_hwnd, out point);

                    if ((point.X >= 0 && point.X <= MAX_X) &&
                        (point.Y >= 0 && point.Y <= MAX_Y))
                    {
                        this.m_oldPoint = point;
                        this.m_leave = false;
                    }
                    else
                    {
                        m_leave = true;
                    }
                }
            }

            return m_oldPoint;
        }

        #endregion

        #region 鼠标事件

        /// 添加鼠标移动事件
        public void AddMouseMoveEvent(XMouseHandler<XMouseEventArgs> func)
        {
            m_mouseMove += func;
        }
        /// 添加鼠标离开事件
        public void AddMouseAwayEvent(XMouseHandler<XMouseEventArgs> func)
        {
            m_mouseAway += func;
        }
        /// 添加鼠标按下事件
        public void AddMouseDownEvent(XMouseHandler<XMouseEventArgs> func)
        {
            m_mouseDown += func;
        }

        /// 响应鼠标移动事件
        public void OnMouseMove(XMouseEventArgs args)
        {
            XMouseHandler<XMouseEventArgs> temp = m_mouseMove;
            if(temp != null)
            {
                temp.Invoke(args);
            }
        }
        /// 响应鼠标离开事件
        public void OnMouseAway(XMouseEventArgs args)
        {
            XMouseHandler<XMouseEventArgs> temp = m_mouseAway;
            if(temp != null)
            {
                temp.Invoke(args);
            }
        }
        /// 响应鼠标按下事件
        public void OnMouseDown(XMouseEventArgs args)
        {
            XMouseHandler<XMouseEventArgs> temp = m_mouseDown;
            if(temp != null)
            {
                temp.Invoke(args);
            }
        }

        /// 鼠标事件的处理
        public void MouseEventHandler()
        {
            XMouseEventArgs args;
            XPoint point = GetMousePoint();
            XMouseButtons vKey = GetCurDownMouse();

            if(!isLeave())
            {
                if(vKey != XMouseButtons.None)
                {
                    args = new XMouseEventArgs(point.X, point.Y, vKey);
                    this.OnMouseDown(args); 
                }

                args = new XMouseEventArgs(point.X, point.Y, vKey);
                this.OnMouseMove(args);
            }
            else
            {
                args = new XMouseEventArgs(-1, -1, true);
                this.OnMouseAway(args);
            }
        }

        #endregion
    }
}
