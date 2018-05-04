using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public struct XSize
    {
        private Int32 m_width;
        private Int32 m_height;

        public XSize(Int32 width, Int32 height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("尺寸大小不合法");
            this.m_width = width;
            this.m_height = height;
        }

        public Int32 GetWidth()  
        {  
            return this.m_width;  
        }  
  
        public void SetWidth(Int32 width)  
        {  
            this.m_width = width;  
        }  
  
        public Int32 GetHeight()  
        {  
            return this.m_height;  
        }  
  
        public void SetHeight(Int32 height)  
        {  
            this.m_height = height;  
        }
    }
}
