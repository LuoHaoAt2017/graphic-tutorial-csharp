using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_tutorial_csharp.chapter5
{
    class Chapter
    {
        public void print()
        {
            // x and y must be public to access
            // initialization occur after construction
            Circle c1 = new Circle { x = 1.0f, y = 2.0f };
            Circle c2 = new Circle(2.0f, 3.0f);
            Circle c3 = new Circle(2.0f, 3.0f) { x = 1.0f, y = 2.0f};
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