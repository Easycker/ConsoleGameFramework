using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 游戏运行接口
    /// </summary>
    public interface IXGame
    {
        void Run();
    }

    class XRun
    {
        static void Main(string[] args)
        {
            // XGameEngine.Run(new DemoGame()); 
            XGameEngine.Run(new TestGame());
        }
    }

    // class DemoGame : XGame { }
}
