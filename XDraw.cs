using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public sealed class XDraw
    {
        /// <summary>
        /// 绘制样式符号
        /// </summary>
        private XSymbol m_symbol;
        /// <summary>
        /// 控制台背景色
        /// </summary>
        private ConsoleColor m_backColor;

        /// <summary>
        /// 构造函数
        /// </summary>
        public XDraw()
        {
            this.m_symbol = XSymbol.RECT_EMPTY;
            this.m_backColor = ConsoleColor.Black;
        }

        #region 绘制字符串

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text"></param>  
        /// <param name="point"></param>  
        /// <param name="color"></param>  
        public void DrawText(String text, XPoint point, ConsoleColor color)  
        {  
            DrawText(text, point.X, point.Y, color);  
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">需要绘制的字符串</param>
        /// <param name="rect">绘制范围</param>
        /// <param name="color">字符串颜色</param>
        public void DrawText(String text, XRect rect, ConsoleColor color)
        {
            rect.Adjust(ref rect);

            // 空字符串不必处理
            if (text == "") return;

            // 反色处理
            Console.BackgroundColor = this.m_backColor;
            Console.ForegroundColor = (this.m_backColor == color ? (ConsoleColor)(15 - (Int32)this.m_backColor) : color);
            Console.SetCursorPosition(rect.GetX(), rect.GetY());

            // 绘制区域可容纳的字节数
            Int32 rectLen = rect.GetWidth() * rect.GetHeight() << 1;
            // 字符串字节数
            Int32 textLen = XText.GetLength(text);
            // 截断字符串以适应绘制范围
            text = XText.CutText(text, textLen > rectLen ? rectLen : textLen);
            // 字符串换行
            // text = XText.LineBreakText(text, rect.GetWidth());
            String[] texts = text.Split(Environment.NewLine.ToCharArray());

            Int32 count = 0;
            foreach (String s in texts)
            {
                if (s != "")
                {
                    Console.SetCursorPosition(rect.GetX(), rect.GetY()+count);
                    Console.Write(s);
                    count++;
                }
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="width">绘制范围宽度</param>  
        /// <param name="height">绘制范围高度</param>  
        /// <param name="color">颜色</param>  
        public void DrawText(String text, Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)  
        {  
            DrawText(text, new XRect(x, y, width, height), color);  
        }  
  
        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="point">位置</param>  
        /// <param name="width">绘制范围宽度</param>  
        /// <param name="height">绘制范围高度</param>  
        /// <param name="color">颜色</param>  
        public void DrawText(String text, XPoint point, Int32 width, Int32 height, ConsoleColor color)  
        {  
            DrawText(text, new XRect(point, width, height), color);  
        }  
  
        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">绘制范围尺寸</param>  
        /// <param name="color">颜色</param>  
        public void DrawText(String text, Int32 x, Int32 y, XSize size, ConsoleColor color)  
        {  
            DrawText(text, new XRect(x, y, size), color);  
        }  
  
        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void DrawText(String text, XPoint point, XSize size, ConsoleColor color)  
        {  
            DrawText(text, new XRect(point, size), color);  
        }  
  
        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">光标列位置</param>  
        /// <param name="y">光标行位置</param>  
        /// <param name="color">前景色</param>  
        public void DrawText(String text, Int32 x, Int32 y, ConsoleColor color)  
        {  
            // 不处理空字符串  
            if (text == "") return;
            
            // 反色处理  
            Console.BackgroundColor = this.m_backColor;  
            Console.ForegroundColor = this.m_backColor == color ? (ConsoleColor)(15 - (Int32)this.m_backColor) : color;

            Console.SetCursorPosition(x >= Console.WindowWidth ? Console.WindowWidth - 1 : x, y);  
  
            // 绘制  
            Console.Write(text);  
            // 复位
            Console.SetCursorPosition(0, 0);  
        }

        #endregion

        #region 绘制矩形

        public void DrawRect(XRect rect, ConsoleColor color)
        {
            // 调整矩形
            rect.Adjust(ref rect);

            int x = rect.GetX();
            int y = rect.GetY();
            int width = rect.GetWidth();
            int height = rect.GetHeight();

            // 根据符号设置对应的颜色
            if (m_symbol == XSymbol.DEFAULT)
            {
                Console.BackgroundColor = color;
            }
            else
            {
                Console.BackgroundColor = this.m_backColor;  
                Console.ForegroundColor = this.m_backColor == color ? (ConsoleColor)(15 - (Int32)this.m_backColor) : color;  
            }

            // 获取符号对应的字符串
            String charSymbol = XSymbolHelper.GetStringFromSymbol(m_symbol);

            // 绘制列
            for (Int32 i = 0; i < width; i++)
            {
                Int32 ix = x + (i << 1);
                if (ix >= Console.WindowWidth)
                    ix = Console.WindowWidth - 1;

                Console.SetCursorPosition(ix, y);
                Console.Write(charSymbol);

                Console.SetCursorPosition(ix, y + height -1);
                Console.Write(charSymbol);
            }

            // 绘制行
            for (Int32 i = 0; i < height; i++)
            {
                Int32 ix = x + (width << 1) - 2;
                if (ix >= Console.WindowWidth)
                    ix = Console.WindowWidth - 1;

                Console.SetCursorPosition(x, y + i);
                Console.Write(charSymbol);

                Console.SetCursorPosition(ix, y + i);
                Console.Write(charSymbol);
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="x">列</param>  
        /// <param name="y">行</param>  
        /// <param name="width">宽度</param>  
        /// <param name="height">高度</param>  
        /// <param name="color">颜色</param>  
        public void DrawRect(Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)  
        {  
            DrawRect(new XRect(x, y, width, height), color);  
        }  
  
        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void DrawRect(XPoint point, XSize size, ConsoleColor color)  
        {  
            DrawRect(new XRect(point, size), color);  
        }  
  
        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void DrawRect(Int32 x, Int32 y, XSize size, ConsoleColor color)  
        {  
            DrawRect(new XRect(x, y, size), color);  
        }  
  
        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="width">宽</param>  
        /// <param name="height">高</param>  
        /// <param name="color">颜色</param>  
        public void DrawRect(XPoint point, Int32 width, Int32 height, ConsoleColor color)  
        {  
            DrawRect(new XRect(point, width, height), color);  
        }

        #endregion

        #region 填充矩形

        public void FillRect(XRect rect, ConsoleColor color)
        {
             // 调整矩形
            rect.Adjust(ref rect);

            int x = rect.GetX();
            int y = rect.GetY();
            int width = rect.GetWidth();
            int height = rect.GetHeight();

            // 根据符号设置对应的颜色
            if (m_symbol == XSymbol.DEFAULT)
            {
                Console.BackgroundColor = color;
            }
            else
            {
                Console.BackgroundColor = this.m_backColor;  
                Console.ForegroundColor = this.m_backColor == color ? (ConsoleColor)(15 - (Int32)this.m_backColor) : color;  
            }

            // 获取符号对应的字符串
            String charSymbol = XSymbolHelper.GetStringFromSymbol(m_symbol);

            StringBuilder str_b = new StringBuilder();
            for (Int32 i = 0; i < width; i++)
            {
                str_b.Append(charSymbol);
            }

            for (Int32 i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(str_b.ToString());
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="x">列</param>  
        /// <param name="y">行</param>  
        /// <param name="width">宽度</param>  
        /// <param name="height">高度</param>  
        /// <param name="color">颜色</param>  
        public void FillRect(Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)  
        {  
            FillRect(new XRect(x, y, width, height), color);  
        }  
  
        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void FillRect(XPoint point, XSize size, ConsoleColor color)  
        {  
            FillRect(new XRect(point, size), color);  
        }  
  
        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void FillRect(Int32 x, Int32 y, XSize size, ConsoleColor color)  
        {  
            FillRect(new XRect(x, y, size), color);  
        }  
  
        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="width">宽</param>  
        /// <param name="height">高</param>  
        /// <param name="color">颜色</param>  
        public void FillRect(XPoint point, Int32 width, Int32 height, ConsoleColor color)  
        {  
            FillRect(new XRect(point, width, height), color);  
        }

        #endregion

        /// <summary>
        /// 获取控制台的绘制符号
        /// </summary>
        /// <returns></returns>
        public XSymbol GetDrawSymbol()
        {
            return this.m_symbol;
        }

        /// <summary>
        /// 设置控制台的绘制符号
        /// </summary>
        /// <param name="symbol"></param>
        public void SetDrawSymbol(XSymbol symbol)
        {
            this.m_symbol = symbol;
        }

        /// <summary>
        /// 获取控制台背景色
        /// </summary>
        /// <returns></returns>
        public ConsoleColor GetBackColor()
        {
            return this.m_backColor;
        }

        /// <summary>
        /// 设置控制台背景色
        /// </summary>
        /// <param name="color"></param>
        public void SetBackColor(ConsoleColor color)
        {
            this.m_backColor = color;
        }

        /// <summary>
        /// 使用指定颜色清屏
        /// </summary>
        public void Clear(ConsoleColor color)
        {
            this.m_symbol = XSymbol.DEFAULT;
            this.m_backColor = color;
            FillRect(0, 0, Console.WindowWidth>>1, Console.WindowHeight, color);
        }
    }
}
