using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 通用游戏类
    /// </summary>
    public abstract class XGame : IXGame
    {
        #region API 函数

        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        #endregion

        #region XGame 类字段

        /// <summary>
        /// 画面刷新速率
        /// </summary>
        private Int32 m_updateRate;
        
        /// <summary>
        /// 当前帧数
        /// </summary>
        private Int32 m_fps;

        /// <summary>
        /// 记录帧数
        /// </summary>
        private Int32 m_tickCount;

        /// <summary>
        /// 游戏的上一次运行时间
        /// </summary>
        private Int32 m_lastTime;

        /// <summary>
        /// 游戏是否结束
        /// </summary>
        private Boolean m_xGameOver;

        #endregion

        #region 输入设备字段

        /// 控制台句柄
        private IntPtr m_hwnd = IntPtr.Zero;

        /// 键盘输入设备
        private XKeyboard m_dc_keyboard;
        /// 鼠标输入设备
        private XMouse m_dc_mouse;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public XGame()
        {
            m_xGameOver = false;

            m_hwnd = FindWindow(null, GetTitle());
            m_dc_keyboard = new XKeyboard();
            m_dc_mouse = new XMouse(m_hwnd);

            // 订阅键盘事件
            // m_dc_keyboard.addKeyDownEvent(GameKeyDown);
            // m_dc_keyboard.addKeyUpEvent(GameKeyUp);
            
            // 订阅鼠标事件
            // m_dc_mouse.AddMouseMoveEvent(GameMouseMove);
            // m_dc_mouse.AddMouseAwayEvent(GameMouseAway);
            // m_dc_mouse.AddMouseDownEvent(GameMouseDown);
        }

        #endregion

        #region 游戏输入设备

        /// 获取键盘设备
        internal XKeyboard GetKeyboardDevice()
        {
            return m_dc_keyboard;
        }

        /// 获取鼠标设备
        internal XMouse GetMouseDevice()
        {
            return m_dc_mouse;
        }

        #endregion

        #region 游戏输入事件

        /// 键盘按下虚拟函数
        protected virtual void GameKeyDown(XKeyboardEventArgs args)
        {
            // 此处处理键盘按下事件
        }
        /// 键盘释放虚拟函数
        protected virtual void GameKeyUp(XKeyboardEventArgs args)
        {
            // 此处处理键盘释放事件
        }

        /// 鼠标移动虚拟函数
        protected virtual void GameMouseMove(XMouseEventArgs args)
        {
            // 此处处理鼠标移动事件
        }
        
        /// 鼠标离开虚拟函数
        protected virtual void GameMouseAway(XMouseEventArgs args)
        {
            // 此处处理鼠标离开事件
        }

        /// 鼠标按下虚拟函数
        protected virtual void GameMouseDown(XMouseEventArgs args)
        {
            // 此处处理鼠标按下事件
        }

        #endregion

        #region 游戏运行时

        /// <summary>
        /// 游戏初始化
        /// </summary>
        protected abstract void GameInit();

        /// <summary>
        /// 游戏逻辑
        /// </summary>
        protected abstract void GameLoop();

        /// <summary>
        /// 游戏结束
        /// </summary>
        protected abstract void GameExit();

        /// 游戏输入
        private void GameInput()
        {
            // 处理键盘事件
            this.GetKeyboardDevice().KeyboardEventsHandler();
            // 处理鼠标事件
            this.GetMouseDevice().MouseEventsHandler();
        }

        #endregion

        #region 游戏设置函数

        /// <summary>
        /// 设置画面刷新速率
        /// </summary>
        /// <param name="rate">画面刷新一次所经时间(ms)</param>
        protected void SetUpdateRate(Int32 rate)
        {
            this.m_updateRate = rate;
        }

        /// <summary>
        /// 获取画面刷新速率
        /// </summary>
        /// <returns>画面每秒刷新的次数</returns>
        protected Int32 GetUpdateRate()
        {
            return 1000 / this.m_updateRate;
        }

        /// <summary>
        /// 计算 FPS
        /// </summary>
        protected void SetFPS()
        {
            Int32 ticks = Environment.TickCount;
            m_tickCount += 1;
            if (ticks - m_lastTime >= 1000)
            {
                m_fps = m_tickCount;
                m_tickCount = 0;
                m_lastTime = ticks;
            }
        }

        /// <summary>
        /// 获取 FPS
        /// </summary>
        /// <returns></returns>
        protected Int32 GetFPS()
        {
            return this.m_fps;
        }

        /// <summary>
        /// 设置延迟
        /// </summary>
        private void Delay()
        {
            this.Delay(1);
        }
        private void Delay(Int32 time)
        {
            Thread.Sleep(time);
        }

        /// <summary>
        /// 控制游戏结束
        /// </summary>
        /// <param name="gameOver"></param>
        protected void SetGameOver(Boolean gameOver)
        {
            this.m_xGameOver = gameOver;
        }

        /// <summary>
        /// 检查游戏是否结束
        /// </summary>
        /// <returns></returns>
        protected Boolean isGameOver()
        {
            return this.m_xGameOver;
        }

        /// <summary>
        /// 设置控制台标题
        /// </summary>
        /// <param name="title"></param>
        protected void SetTitle(string title)
        {
            Console.Title = title;
        }

        /// <summary>
        /// 获取控制台标题
        /// </summary>
        /// <returns></returns>
        protected string GetTitle()
        {
            return Console.Title;
        }

        /// <summary>
        /// 设置光标是否可见
        /// </summary>
        /// <param name="isVisible"></param>
        protected void SetCursorVisible(Boolean isVisible)
        {
            Console.CursorVisible = isVisible;
        }

        /// <summary>
        /// 关闭游戏并释放资源
        /// </summary>
        private void Close()
        { }

        #endregion

        #region 游戏启动接口

        /// <summary>
        /// 游戏运行方法
        /// </summary>
        public void Run()
        {
            this.GameInit(); // 游戏初始化

            Int32 startTime = 0;
            while (!this.isGameOver())
            {
                startTime = Environment.TickCount; // 启动游戏计时
                this.SetFPS();                     // 计算 FPS
                this.GameLoop();                   // 游戏主逻辑
                while (Environment.TickCount - startTime < this.m_updateRate)
                    this.Delay();                  // 保持一定的 FPS
            }

            this.GameExit(); // 退出游戏
            this.Close();    // 释放资源
        }

        #endregion
    }
}
