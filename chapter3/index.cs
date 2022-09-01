using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 迭代器
namespace graphic_tutorial_csharp.chapter3
{
    class Chapter
    {
        public void print()
        {
            string[] colors = { "Red", "Green", "Blue " };

            Spectrum spectrum = new Spectrum(colors);
            foreach (string elem in spectrum)
            {
                Console.WriteLine(elem);
            }

            ColorBox colorBox = new ColorBox(colors);
            if (colorBox != null)
            {
                foreach (string elem in colorBox)
                {
                    Console.WriteLine(elem);
                }
            }

            MagicBox magicBox = new MagicBox(colors);
            if (magicBox != null)
            {
                foreach (string elem in magicBox)
                {
                    Console.WriteLine(elem);
                }
            }

            IEnumerable<string> enumerator = magicBox.BlackAndWhite(colors);
            foreach (string elem in enumerator)
            {
                Console.WriteLine(elem);
            }


        }

        // 枚举器的迭代器模式
        class ColorBox
        {
            private string[] _colors;
            public ColorBox(string[] colors)
            {
                this._colors = colors;
            }
            // 返回枚举器
            public IEnumerator<string> GetEnumerator()
            {
                return BlackAndWhite(_colors);
            }

            public IEnumerator<string> BlackAndWhite(string[] colors)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    yield return colors[i];
                }
            }
        }

        // 可枚举类型的迭代器模式
        class MagicBox
        {
            private string[] _colors;
            public MagicBox(string[] colors)
            {
                this._colors = colors;
            }
            // 返回枚举器
            public IEnumerator<string> GetEnumerator()
            {
                IEnumerable<string> enumerable = BlackAndWhite(_colors);
                return enumerable.GetEnumerator();
            }

            public IEnumerable<string> BlackAndWhite(string[] colors)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    yield return colors[i];
                }
            }
        }

        class Spectrum : IEnumerable
        {
            string[] _colors;

            public Spectrum(string[] colors)
            {
                this._colors = new string[colors.Length];

                for (int i = 0; i < colors.Length; i++)
                {
                    this._colors[i] = colors[i];
                }
            }

            public IEnumerator GetEnumerator()
            {
                return new ColorEnumerator(_colors);
            }
        }

        class ColorEnumerator : IEnumerator
        {
            string[] _colors;
            int _position = -1;

            public ColorEnumerator(string[] colors)
            {
                _colors = new string[colors.Length];
                for (int i = 0; i < colors.Length; i++)
                {
                    _colors[i] = colors[i];
                }
            }

            public object Current
            {
                get
                {
                    if (_position > _colors.Length - 1)
                    {
                        throw new InvalidOperationException();
                    }
                    else if (_position < 0)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {

                        return _colors[_position];
                    }
                }
            }

            public bool MoveNext()
            {
                if (_position < _colors.Length - 1)
                {
                    _position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }
}
