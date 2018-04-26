using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleGameFramework
{
    internal abstract class XInput
    {
        // 关于 0x8000 (http://bingtears.iteye.com/blog/663149)
        internal const Int32 KEY_STATE = 0x8000;

        /// <summary>
        /// 判断被调用时指定虚拟键的状态
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        protected static extern Int16 GetAsyncKeyState(System.Int32 vKey);

        /// <summary>
        /// 获取光标位置
        /// </summary>
        /// <param name="xp"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        protected static extern Boolean GetCursorPosition(out XPoint xp);

        /// <summary>
        /// 将屏幕坐标转换为工作区坐标
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="xp"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        protected static extern Int16 CovertPosition(IntPtr hwnd, out XPoint xp);
    }
}
