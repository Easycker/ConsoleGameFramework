using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 游戏启动类
    /// </summary>
    public sealed class XGameEngine
    {
        public static void Run(IXGame game)
        {
            if (game == null)
            {
                Console.WriteLine("引擎未初始化");
                Console.ReadKey();
            }
            else
            {
                game.Run();
            }
        }
    }
}
