using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public class TestGame1 : XGame
    {
        private Int32 m_ticks;
        private Int32 m_lasttime;

        protected override void GameInit()
        {
            SetTitle("Hello World");
            SetUpdateRate(10);
            SetCursorVisible(false);

            Console.WriteLine("游戏初始化成功！");
            m_lasttime = Environment.TickCount;
        }

        protected override void GameDraw(XDraw draw)
        {
            throw new NotImplementedException();
        }

        protected override void GameLoop()
        {
            if (m_ticks++ < 15)
            {
                // 游戏运行主逻辑
                Console.WriteLine(string.Format("游戏运行中，第 {0} 帧，耗时 {1} 毫秒", m_ticks, Environment.TickCount - m_lasttime));
                m_lasttime = Environment.TickCount;
            }
            else
            {
                // 游戏退出逻辑
                SetGameOver(true);
            }
        }
        protected override void GameExit()
        {
            Console.WriteLine("游戏结束！");
            Console.ReadKey();
        }
    }
}
