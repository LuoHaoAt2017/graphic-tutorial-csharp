using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 隐式转换
// 显式转换
// 强制转换

// 短类型到长类型的转换
// 长类型到短类型的转换
// 

namespace graphic_tutorial_csharp.chapter5
{
    class Chapter
    {
        public void print()
        {
            Console.WriteLine();
        }
    }

    class Circle
    {
        public float x;
        public float y;

        public Circle()
        {

        }

        public Circle(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Geometry
    {
        private readonly int sides = 0;

        private float area = 0;

        Geometry(float a, float b, float c)
        {
            sides = 3;
        }

        Geometry(float a, float b)
        {
            sides = 4;
            area = a * b;
        }

        // 只能在声明或者构造函数中改变值
        //public void setSide(int value)
        //{
        //    sides = value;
        //}

        public float getArea()
        {
            return area;
        }

        public void print()
        {
            Console.WriteLine(sides);
        }
    }
}