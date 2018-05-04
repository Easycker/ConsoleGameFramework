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
        /*
            static void Main(string[] args)
            {
                XGameEngine.Run(new TestGame2());
            }
        */

        static void Main(string[] args)
        {
            XDraw draw = new XDraw();

            // 绘制字符串
            draw.DrawText("测试点结构", 2, 1, ConsoleColor.Blue);
            
            // 初始化一个点 point1
            XPoint point1 = new XPoint(1, 2);
            // 初始化一个点 point2
            XPoint point2 = new XPoint(3, 4);
            
            // 绘制 point1  
            draw.DrawText("点1：" + point1, 4, 2, ConsoleColor.White);  
            // 绘制 point2  
            draw.DrawText("点2：" + point2, 4, 3, ConsoleColor.White);  
            
            // 绘制两点相加  
            draw.DrawText("点1+点2：" + (point1 + point2), 4, 4, ConsoleColor.White);  
            // 绘制两点相减  
            draw.DrawText("点1-点2：" + (point1 - point2), 4, 5, ConsoleColor.White);  
            // 绘制两点是否相等  
            draw.DrawText("点1==点2：" + (point1 == point2), 4, 6, ConsoleColor.White);  
            // 绘制两点是否不等  
            draw.DrawText("点1!=点2：" + (point1 != point2), 4, 7, ConsoleColor.White);

            /*--- ---*/
  
            draw.DrawText("测试矩形结构", 1, 9, 2, 3, ConsoleColor.Red);  
            
            // 初始化一个矩形  
            XRect rect = new XRect(2, 2, 5, 8);  
            draw.DrawText("矩形：" + rect, 4, 12, ConsoleColor.White);  
            
            // 缩放矩形
            rect.Inflate(1, 1);
            draw.DrawText("矩形缩放[1,1]：" + rect, 4, 13, ConsoleColor.White);
  
            // 设置绘制符号  
            draw.SetDrawSymbol(XSymbol.RECT_SOLID);
            draw.DrawRect(15, 0, 25, 25, ConsoleColor.White);
           
            /*--- ---*/

            draw.DrawText("测试矩阵结构", 32, 1, ConsoleColor.Green);
  
            // 初始化第 1 个矩阵  
            XMatrix matrix1 = new XMatrix(3, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 1;
            matrix1[2, 2] = 3;

            // 初始化第 2 个矩阵  
            XMatrix matrix2 = new XMatrix(new Int32[3, 3]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            });

            // 初始化第 3 个矩阵
            XMatrix matrix3 = new XMatrix(new Int32[2, 3]
            {
                {1,2,3},
                {4,5,6}
            });

            // 绘制矩阵
            draw.DrawText("矩阵1：", 32, 2, ConsoleColor.White);  
            draw.DrawText(matrix1.ToString(), 16, 3, 5, 3, ConsoleColor.White);  
             
            draw.DrawText("矩阵2：", 42, 2, ConsoleColor.White);  
            draw.DrawText(matrix2.ToString(), 21, 3, 5, 3, ConsoleColor.White);  
            
            draw.DrawText("矩阵3：", 52, 2, ConsoleColor.White);  
            draw.DrawText(matrix3.ToString(), 26, 3, 5, 3, ConsoleColor.White);  
  
            // 矩阵运算 
            draw.DrawText("矩阵1+矩阵2：", 32, 7, ConsoleColor.White);  
            draw.DrawText((matrix1 + matrix2).ToString(), 16, 8, 5, 3, ConsoleColor.White);  
             
            draw.DrawText("矩阵2-矩阵1：", 48, 7, ConsoleColor.White);  
            draw.DrawText((matrix2 - matrix1).ToString(), 24, 8, 5, 3, ConsoleColor.White);  
              
            draw.DrawText("矩阵3*矩阵2：", 64, 7, ConsoleColor.White);  
            draw.DrawText((matrix3 * matrix2).ToString(), 32, 8, 7, 3, ConsoleColor.White);  
  
            // 顺时针旋转矩阵 90 度   
            matrix2.Rotate(XRotateMode.R90);  
            draw.DrawText("顺时针90度旋转矩阵2：", 32, 12, ConsoleColor.White);  
            draw.DrawText(matrix2.ToString(), 16, 13,5,3, ConsoleColor.White);  
            matrix2.Rotate(XRotateMode.L90); // 为了测试先恢复矩阵状态
           
            // 顺时针旋转矩阵 180 度
            matrix2.Rotate(XRotateMode.R180);  
            draw.DrawText("顺时针180度旋转矩阵2：", 54, 12, ConsoleColor.White);  
            draw.DrawText(matrix2.ToString(), 27, 13, 5, 3, ConsoleColor.White);
            matrix2.Rotate(XRotateMode.L180);  
            
            // 顺时针旋转矩阵 270 度  
            matrix2.Rotate(XRotateMode.R270);  
            draw.DrawText("顺时针270度旋转矩阵2：", 32, 17, ConsoleColor.White);  
            draw.DrawText(matrix2.ToString(), 16, 18, 5, 3, ConsoleColor.White);

            matrix3.Rotate(XRotateMode.L90);  
            draw.DrawText("逆时针90度旋转矩阵3：", 54, 17, ConsoleColor.White);  
            draw.DrawText(matrix3.ToString(), 27, 18, 4, 4, ConsoleColor.White);  
  
            // 设置绘制符号  
            draw.SetDrawSymbol(XSymbol.RECT_EMPTY);  
            // 填充矩形  
            draw.FillRect(2,15,5,5,ConsoleColor.Yellow);  
            
            //设置绘制符号  
            draw.SetDrawSymbol(XSymbol.RHOMB_SOLID);  
            //填充矩形  
            draw.FillRect(3, 16, 2, 3, ConsoleColor.Blue);  
            
            //设置绘制符号  
            draw.SetDrawSymbol(XSymbol.RECT_SOLID);  
            //填充矩形  
            draw.FillRect(7, 17, 4, 3, ConsoleColor.Blue);  
  
            //绘制一段文字  
            draw.DrawText("渲染测试", 2, 21, 12, 5, ConsoleColor.Cyan);  
  
            Console.ReadLine();  
        }
    }

    // class DemoGame : XGame { }
}
