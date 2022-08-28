using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    // class Spectrum
    // {
    //   string[] _colors;

    //   public Spectrum(string[] colors)
    //   {
    //     this._colors = new string[colors.Length];
    //     for (int i = 0; i < colors.Length; i++)
    //     {
    //       this._colors[i] = colors[i];
    //     }
    //   }

    //   public IEnumerator<string> GetEnumerator()
    //   {
    //     return SpectrumEnumerator(_colors);
    //   }

    //   public IEnumerator<string> SpectrumEnumerator(string[] colors)
    //   {
    //     for (int i = 0; i < colors.Length; i++)
    //     {
    //       yield return colors[i];
    //     }
    //   }
    // }

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
