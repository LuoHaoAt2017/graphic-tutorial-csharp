using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 深入地理解类

namespace graphic_tutorial_csharp.chapter6
{
    class Chapter
    {
        public static int MinVal;

        static public int MaxVal;

        public Chapter()
        {
             
        }

        public void print()
        {
            test3();
        }

        // 静态字段成员
        public void test1()
        {
            Node.version = "1.0"; // 不能以实例成员加点运算符来访问静态成员
            Node node1 = new Node(1, "2.0");
            Node node2 = new Node(2, "3.0");
            node1.print();
            node2.print();
        }

        // 静态函数成员
        public static void test2()
        {
            Console.WriteLine("静态函数成员不能访问实例成员；实例函数成员可以访问静态成员");
            Console.WriteLine("假设能在静态函数成员中访问实例成员，那么必须先实例化类，然后才能访问实例成员。但是静态函数可以在不实例化的情况下就可以调用，不实例化就无法访问实例成员。前后矛盾。");
            MinVal = 1;
            MaxVal = 2;
        }

        // 静态构造函数
        public void test3()
        {
            Circle circle1 = new Circle();
            Circle.x = 1.0f;
            Circle.y = 1.0f;
            Circle.r = 1.0f;
            circle1.version = "1.0";
            circle1.print();

            Circle circle2 = new Circle();
            Circle.x = 2.0f;
            Circle.y = 2.0f;
            Circle.r = 2.0f;
            circle2.version = "2.0";
            circle2.print();

            if (circle1 == circle2)
            {
                Console.WriteLine("circle1 == circle2");
            } else
            {
                Console.WriteLine("circle1 != circle2");
            }
        }
    }

    class Circle
    {
        public string version;
        public static float x;
        public static float y;
        public static float r;
        // 静态构造函数中不允许出现访问修饰符
        // 静态构造函数必须无参数
        static Circle(){}

        public void print()
        {
            Console.WriteLine($"x: {x}, y: {y}, r: {r}");
        }
    }

    class Node
    {
        private string id;
        private int value;
        private Node next;
        public static string version = "1.0";

        public Node(int value)
        {
            this.value = value;
            version = "2.0"; // 不能以this的方式来访问静态成员，可以使用 Node.version 的方式来访问静态成员，可以进一步简写成 version。
        }


        public Node(int value, string version)
        {
            this.value = value;
            Node.version = version;
        }

        public void print()
        {
            Console.WriteLine($"verson: {Node.version}");
        }
    }
}
