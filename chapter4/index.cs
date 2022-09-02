using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 委托是恒定的
// 委托对象被创建后不能再被改变
namespace graphic_tutorial_csharp.chapter4
{
    delegate void MyDel(int value); // 声明委托类型

    class Chapter
    {
        public void print()
        {

            MyDel del; // 声明委托变量
            Random rand = new Random();
            int random = rand.Next(99);
            // 创建委托类型的对象
            del = random > 50 ? new MyDel(this.PrintHeight) : new MyDel(this.PrintLow);
            del(random); // 调用委托
        }

        public void PrintLow(int value)
        {
            Console.Write("low {0}", value);
        }

        public void PrintHeight(int value)
        {
            Console.Write("height {0}", value);
        }
    }
}
