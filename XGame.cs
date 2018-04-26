using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 通用游戏类
    /// </summary>
    public abstract class XGame : IXGame
    {
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

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public XGame()
        {
            m_xGameOver = false;
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
