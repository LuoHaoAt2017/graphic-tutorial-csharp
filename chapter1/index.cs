using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * 在不同数据类型上执行相同的指令。
 * 类型不是对象，而是对象的模板。
 * 泛型类型不是类型，而是类型的模板。
 * 自定义类型 和 预定义类型
 * 所有的C#对象最终都是从 object 继承而来。
 * 
 * 
 */
namespace graphic_tutorial_csharp.chapter1
{
    internal class Chapter
    {
        enum Rainbow
        {
            Unknown = -1,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        enum Direction
        {
            North,
            East,
            South,
            West,
        }

        public static Dictionary<int, string> EnumNamedValues<T>() where T : Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));
            foreach (int item in values)
            {
                result.Add(item, Enum.GetName(typeof(T), item)!); // 加了一个 ！
            }
            return result;
        }

        public void print()
        {

        }

        public void printEnum()
        {
            var rainbow = EnumNamedValues<Rainbow>();
            foreach (var pair in rainbow)
            {
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");
            }
            var direction = EnumNamedValues<Direction>();
            foreach (var pair in direction)
            {
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");
            }
        }

        public void printStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while (stack.Count > 0)
            {
                int x = stack.Pop();
                Console.WriteLine("stack elem: {0}", x);
            }
        }

        public void TestEnum()
        {
            int status = 3;
            Rainbow rainbow;
            if (Enum.IsDefined(typeof(Rainbow), status))
            {
                rainbow = (Rainbow)3;
            }
            else
            {
                rainbow = Rainbow.Unknown;
            }

            string[] names = Enum.GetNames(typeof(Rainbow));
            foreach (string name in names)
            {
                Rainbow value = (Rainbow)Enum.Parse(typeof(Rainbow), name);
                Console.WriteLine("{0}:{1:D}", name, value);
            }
            var values = Enum.GetValues(typeof(Rainbow));
            foreach (Rainbow value in values)
            {
                Console.WriteLine("{0}:{1:D}", value, value);
            }
        }
    }

    public class Employee
    {
        public Employee(string name, int id) => (Name, ID) = (name, id);
        public string Name { get; set; }
        private int ID { get; set; }
    }

    public class GenericList<T> where T : Employee
    {
        private Node? head;

        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);
            public Node? Next { get; set; }
            public T Data { get; set; }
        }

        public void AddHead(T t)
        {
            Node node = new Node(t) { Next = head };
            head = node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? node = head;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        public T? FindFirstOccurrence(string s)
        {
            Node? node = head;
            T? t = null;
            while (node != null)
            {
                if (node.Data.Name == s)
                {
                    t = node.Data;
                    break;
                } else
                {
                    node = node.Next;
                }
            }
            return t;
        }
    }

    public class CustomStack<T>
    {
        const int MaxStack = 9;
        private T[] stack = new T[MaxStack];
        private int pointer = -1;

        public T pop()
        {
            if (pointer >= 0)
            {
                return stack[pointer--];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void push(T elem)
        {
            if (pointer < stack.Length - 1)
            {
                stack[++pointer] = elem;
            } else {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
