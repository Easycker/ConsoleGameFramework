using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 字符串处理类
    /// </summary>
    sealed internal class XText
    {
        /// <summary>
        /// 获取字符串的字节长度
        /// </summary>
        /// <returns></returns>
        public static Int32 GetLength(String text)
        {
            Byte[] bytes;
            Int32 len = 0;

            for (Int32 i = 0; i < text.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(text.Substring(i,1));
                len += (bytes.Length > 1) ? 2 : 1;
            }

            return len;
        }

        /// <summary>
        /// 按字节长度截取字符串
        /// </summary>
        /// <param name="text">被截取的字符串</param>
        /// <param name="len">字节长度</param>
        /// <returns></returns>
        public static String CutText(String text, Int32 len)
        {
            if (len < 0 || len > GetLength(text))
            {
                throw new ArgumentOutOfRangeException();
            }

            Int32 charLen = 0;
            StringBuilder str_b = new StringBuilder();

            for (Int32 i = 0; i < text.Length && charLen < len; i++)
            {
                charLen += GetLength(text.Substring(i,1));
                str_b.Append(text[i]);
            }

            return str_b.ToString();
        }

        /// <summary>
        /// 按照字符串索引截取相应的字节长度
        /// </summary>
        /// <param name="text">被截取的字符串</param>
        /// <param name="index">字符串索引</param>
        /// <param name="len">字节长度</param>
        /// <returns></returns>
        public static String IndexofText(String text, Int32 index, Int32 len)
        {
            if (index < 0 || index > (text.Length - 1))
                throw new ArgumentOutOfRangeException();
            if (len < 0 || len > GetLength(text))
                throw new ArgumentOutOfRangeException();

            text = text.Substring(index, text.Length - index);

            return CutText(text, len);
        }

        /// <summary>
        /// 控制字符串的换行
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="cols">列：一列为 2 字节</param>
        /// <returns></returns>
        public static String LineBreakText(String text, Int32 cols)
        {
            if (cols < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Int32 len = 0;
            Int32 charLen = 0;

            StringBuilder str_b = new StringBuilder();

            for (Int32 i =0; i<text.Length; i++)
            {
                len = GetLength(text.Substring(i,1));
                charLen += len;

                if (charLen > (cols << 1))
                {
                    str_b.Append(Environment.NewLine);
                    charLen = len;
                }

                str_b.Append(text[i]);
            }

            return str_b.ToString();
        }

    }
}
