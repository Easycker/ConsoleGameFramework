using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public class TestGame2 : XGame
    {
        private Boolean m_bkeydown = false;

        protected override void GameInit()
        {
            // 设置游戏窗口标题
            SetTitle("Hello World");
            // 设置游戏画面刷新频率（每毫秒一次）
            SetUpdateRate(30);
            // 设置光标隐藏
            SetCursorVisible(false);

            Console.WriteLine("游戏初始化成功！");
        }

        protected override void GameLoop()
        {
            // 游戏逻辑

        }
        protected override void GameExit()
        {
            Console.WriteLine("游戏结束！");
            Console.ReadKey();
        }

        protected override void GameKeyDown(XKeyboardEventArgs args)
        {
            if (!m_bkeydown)
            {
                Console.WriteLine("按下键：" + args.GetKey());
                m_bkeydown = true;
            }

            if (args.GetKey() == XKeys.Escape)
            {
                SetGameOver(true);
            }
        }

        protected override void GameKeyUp(XKeyboardEventArgs args)
        {
            Console.WriteLine("释放键：" + args.GetKey());
            m_bkeydown = false;

        }

        protected override void GameMouseAway(XMouseEventArgs args)
        {
            SetTitle("鼠标离开了工作区！");
        }

        protected override void GameMouseMove(XMouseEventArgs args)
        {
            SetTitle("鼠标回到了工作区！");
        }

        protected override void GameMouseDown(XMouseEventArgs args)
        {
            if (args.GetKey() == XMouseButtons.Left)
            {
                Console.SetCursorPosition(15, 2);
                Console.WriteLine("鼠标工作区坐标：" + args.ToString() + " " + args.GetKey().ToString());
            }
            else if (args.GetKey() == XMouseButtons.Right)
            {
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("鼠标工作区坐标：" + args.ToString() + " " + args.GetKey().ToString());
            }
            if (args.GetKey() == XMouseButtons.Middle)
            {
                Console.SetCursorPosition(15, 4);
                Console.WriteLine("鼠标工作区坐标：" + args.ToString() + " " + args.GetKey().ToString());
            }
        }
    }
}
