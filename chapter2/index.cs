using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_tutorial_csharp.chapter2
{
    internal class Chapter
    {

        public void print()
        {
            TestSortable();
        }

        public void TestEquals()
        {
            Circle c1 = new Circle(1, 1, 1);
            Circle c2 = new Circle(1, 1, 1);
            Circle c3 = c1;
            if (c1.Equals(c2))
            {
                Console.WriteLine($"c1 == c2");
            } else
            {
                Console.WriteLine($"c1 != c2");
            }

            if (c1.Equals(c3))
            {
                Console.WriteLine($"c1 == c3");
            }
            else
            {
                Console.WriteLine($"c1 != c3");
            }
        }

        public void TestCircleList()
        {
            List<Circle> circles = new List<Circle>();
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                circles.Add(new Circle(rand.Next(0, 1), rand.Next(0, 1), rand.Next(0, 1)));
            }
            circles.RemoveAt(0);
            foreach (Circle c in circles)
            {
                c.print();
            }
        }

        public void TestContains()
        {
            List<Option> options = new List<Option>();
            options.Add(new Option("JS", "JavaScript"));
            options.Add(new Option("CSS", "CSS"));
            options.Add(new Option("HTML", "HTML"));
            options.Insert(2, new Option("Nginx", "Nginx"));
            options.Remove(new Option("HTML", "HTML"));
            List<Option> skills = new List<Option>()
            {
                new Option("HTTP", "HTTP"),
                new Option("C#", "C Sharp"),
                new Option("HTML", "HTML"),
            };



            foreach (Option skill in skills)
            {
                if (!options.Contains(skill))
                {
                    options.Add(skill);
                }
                else
                {
                    Console.WriteLine("{0} 已经存在", skill.label);
                }
            }
            foreach (Option option in options)
            {
                Console.WriteLine(option.label);
            }
        }
        
        public void TestSortable()
        {
            List<Circle> circles = new List<Circle>();
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                circles.Add(new Circle(rand.Next(), rand.Next(), rand.Next()));
            }
            // circles.Sort();
            foreach (Circle circle in circles)
            {
                Console.WriteLine(circle.radius);
            }
        }

        class Circle
        {
            public int px;

            public int py;

            public int radius;

            public Circle(int x, int y, int r) => (px, py, radius) = (x, y, r);

            public void print()
            {
                Console.WriteLine($"px: {0}, py: {1}, radius: {2}", px, py, radius);
            }
        }

        class Option : IEquatable<Option>
        {
            public string label;

            public string value;

            public Option(string label, string value)
            {
                this.label = label;
                this.value = value;
            }

            public bool Equals(Option? other)
            {
                return this.label == other?.label && this.value == other?.value;
            }
        }
    }
}
