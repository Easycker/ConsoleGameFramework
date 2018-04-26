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

    internal sealed class XMouse : XInput
    {

    }
}
