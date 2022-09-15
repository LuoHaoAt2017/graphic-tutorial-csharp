using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 委托是恒定的
// 委托对象被创建后不能再被改变
namespace graphic_tutorial_csharp.chapter4
{
    delegate void MyDel(int value); // 声明委托类型，委托是类型。
    delegate float Sum(float val1, float val2);
    // 返回类型和标签名指定了委托接受的方法的形式

    class Chapter
    {
        public void print()
        {

        }

        public void test1()
        {
            MyDel del; // 声明委托变量
            Random rand = new Random();
            int random = rand.Next(99);
            // 创建委托类型的对象
            del = random > 50 ? new MyDel(this.PrintHeight) : new MyDel(this.PrintLow);
            del(random); // 调用委托

            del = this.PrintHeight;
            del(random);

            del = this.PrintLow;
            del(random);
        }

        public void test2()
        {
            Random rand = new Random();
            int random = rand.Next(99);
            MyDel del1 = this.PrintHeight;
            MyDel del2 = this.PrintLow;
            MyDel del3 = del1 + del2;
            del3(random); // 调用列表中的每一个方法
        }

        public void test3()
        {
            Sum total = new Sum(this.sum);
            float a = 1.0f, b = 1.0f;
            float result = total(a, b);
            Console.WriteLine("{0}+{1}={2}", a, b, result);
        }

        public void PrintLow(int value)
        {
            Console.WriteLine("low {0}", value);
        }

        public void PrintHeight(int value)
        {
            Console.WriteLine("height {0}", value);
        }

        public float sum(float a, float b)
        {
            return a + b;
        }
    }
}
