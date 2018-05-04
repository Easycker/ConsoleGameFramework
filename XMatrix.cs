using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    /// <summary>
    /// 矩阵旋转模式
    /// </summary>
    public enum XRotateMode
    {
        /// <summary>
        /// 不旋转
        /// </summary>
        None,
        /// <summary>
        /// 顺时针旋转 90 度
        /// </summary>
        R90,
        /// <summary>
        /// 顺时针旋转 180 度
        /// </summary>
        R180,
        /// <summary>
        /// 顺时针旋转 270 度
        /// </summary>
        R270,
        /// <summary>
        /// 逆时针旋转 90 度
        /// </summary>
        L90,
        /// <summary>
        /// 逆时针旋转 180 度
        /// </summary>
        L180,
        /// <summary>
        /// 逆时针旋转 270 度
        /// </summary>
        L270,
    }

    /// <summary>
    /// 自定义矩阵异常类
    /// </summary>
    public class XMatrixException : Exception
    {
        public XMatrixException() : base()
        { }

        public XMatrixException(String msg) : base(msg)
        { }

        public String GetMessage()
        {
            return base.Message;
        }

    }

    public struct XMatrix
    {
        /// <summary>
        /// 矩阵元素
        /// </summary>
        private Int32[,] m_matrix;
        /// <summary>
        /// 矩阵行数
        /// </summary>
        private Int32 m_rows;
        /// <summary>
        /// 矩阵列数
        /// </summary>
        private Int32 m_cols;
        /// <summary>
        /// 矩阵元素总数
        /// </summary>
        private Int32 m_totalCount;
        /// <summary>
        /// 矩阵旋转模式
        /// </summary>
        private XRotateMode m_rotate;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public XMatrix(Int32 row, Int32 col)
        {
            this.m_matrix = new Int32[row, col];
            this.m_rows = m_matrix.GetUpperBound(0) + 1;
            this.m_cols = m_matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = XRotateMode.None;
        }

        public XMatrix(Int32[,] matrix)
        {
            this.m_matrix = matrix;
            this.m_rows = matrix.GetUpperBound(0) + 1;
            this.m_cols = matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = XRotateMode.None;
        }

        /// <summary>
        /// 支持通过下标操作矩阵
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Int32 this[Int32 x, Int32 y]
        {
            get
            {
                if (x < 0 || y < 0 || x > m_rows - 1 || y > m_cols - 1)
                    throw new ArgumentOutOfRangeException();
                return m_matrix[x, y];
            }
            set
            {
                if (x < 0 || y < 0 || x > m_rows - 1 || y > m_cols - 1)
                    throw new ArgumentOutOfRangeException();
                m_matrix[x, y] = value;
            }
        }

        /// <summary>
        /// 获取矩阵数组
        /// </summary>
        /// <returns></returns>
        public Int32[,] GetMatrix()
        {
            return this.m_matrix;
        }

        public void SetMatrix(Int32[,] matrix)
        {
            this.m_matrix = matrix;
            this.m_rows = matrix.GetUpperBound(0) + 1;
            this.m_cols = matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = XRotateMode.None;
        }

        public Int32 GetRows()
        {
            return this.m_rows;
        }

        public Int32 GetCols()
        {
            return this.m_cols;
        }

        public Int32 GetTotalCount()
        {
            return m_totalCount;
        }

        public void SetRotateMode(XRotateMode rotate)
        {
            this.m_rotate = rotate;
        }

        /// <summary>
        /// 矩阵加法
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static XMatrix operator +(XMatrix left, XMatrix right)
        {
            if ((left.GetRows() != right.GetRows()) ||
                (left.GetCols() != right.GetCols()))
            {
                throw new XMatrixException("Error");
            }

            Int32 r = left.GetRows();
            Int32 c = left.GetCols();

            XMatrix newMatrix = new XMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = left[i, j] + right[i, j];
                }
            }

            return newMatrix;
        }

        public XMatrix Add(XMatrix right)
        {
            return this + right;
        }

        /// <summary>
        /// 矩阵减法
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static XMatrix operator -(XMatrix left, XMatrix right)
        {
            if ((left.GetRows() != right.GetRows()) ||
                (left.GetCols() != right.GetCols()))
            {
                throw new XMatrixException("Error");
            }

            Int32 r = left.GetRows();
            Int32 c = left.GetCols();

            XMatrix newMatrix = new XMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = left[i, j] - right[i, j];
                }
            }

            return newMatrix;
        }

        public XMatrix Sub(XMatrix right)
        {
            return this - right;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static XMatrix operator *(XMatrix left, XMatrix right)
        {
            if (left.GetCols() != right.GetRows())
            {
                throw new XMatrixException("Error");
            }

            Int32 lr = left.GetRows();
            Int32 lc = left.GetCols();
            Int32 rc = right.GetCols();

            XMatrix newMatrix = new XMatrix(lr, rc);

            for (Int32 i = 0; i < lr; i++)
            {
                for (Int32 j = 0; j < rc; j++)
                {
                    for(Int32 k =0; k<lc; k++)
                        newMatrix[i, j] = newMatrix[i, j] +left[i, k] * right[k, j];
                }
            }

            return newMatrix;
        }

        public XMatrix Multiply(XMatrix right)
        {
            return this * right;
        }

        /// <summary>
        /// 矩阵旋转
        /// </summary>
        public void Rotate()
        {
            Rotate(this.m_rotate);
        }

        public void Rotate(XRotateMode rotate)
        {
            switch(rotate)
            {
                case XRotateMode.None:
                    break;
                case XRotateMode.R90:
                    RotateR90();
                    break;
                case XRotateMode.R180:
                    RotateR180();
                    break;
                case XRotateMode.R270:
                    RotateR270();
                    break;
                case XRotateMode.L90:
                    RotateL90();
                    break;
                case XRotateMode.L180:
                    RotateL180();
                    break;
                case XRotateMode.L270:
                    RotateL270();
                    break;
                default:
                    break;
            }
        }

        #region 矩阵旋转函数

        private void RotateR90()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[r - j - 1, i];  
                }
            }

            this = newMatrix;
        }

        private void RotateR180()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = this[r - i - 1, c - j - 1];  
                }
            }

            this = newMatrix;
        }

        private void RotateR270()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[j, c - i - 1];  
                }
            }

            this = newMatrix;
        }

        private void RotateL90()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[j, c - i - 1];  
                }
            }

            this = newMatrix;
        }

        private void RotateL180()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = this[r - i - 1, c - j - 1];  
                }
            }

            this = newMatrix;
        }

        private void RotateL270()
        {
            Int32 r = this.GetRows();
            Int32 c = this.GetCols();

            XMatrix newMatrix = new XMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[r - j - 1, i];  
                }
            }

            this = newMatrix;
        }

        #endregion

        /// <summary>
        /// 输出矩阵
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str_b = new StringBuilder();

            for (Int32 i = 0; i < this.GetRows(); i++)
            {
                for (Int32 j = 0; j < this.GetCols(); j++)
                {
                    str_b.Append(m_matrix[i, j] + " ");
                }
                str_b.Append(Environment.NewLine);
            }

            return str_b.ToString();
        }
    }
}
