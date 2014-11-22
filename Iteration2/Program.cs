using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Iteration2
{
    class Program
    {
        private const int IterationCount = 30;
        private const double Radius = 2;
        private const double Step = 0.01;

        static void Main(string[] args)
        {
            int size = Convert.ToInt32( Radius*2/Step);
            var bmp = new Bitmap(size, size);
            for (var im = -Radius; im < Radius; im+=Step)
            {
                for (var real = -Radius; real < Radius; real+=Step)
                {
                    Func<Complex, Complex> function = z => Complex.Log10(z) + Complex.Sinh(z); 
                    var color = CheckPoint(new Complex(real, im),function)
                        ? Color.Red
                        : Color.Black;
                    int x = GetBitmapCoord(real);
                    int y = GetBitmapCoord(im);
                    bmp.SetPixel(x,y,color);
                }
            }
            bmp.Save("result.bmp");
        }

        private static int GetBitmapCoord(double i)
        {
            return Convert.ToInt32((i + Radius)*(1.0/Step));
        }

        static bool CheckPoint(Complex z, Func<Complex, Complex> func)
        {
            for (int i = 0; i < IterationCount; i++)
            {
                if (Complex.Abs(z) > Radius)
                {
                    return false;
                }
                z = func(z);
            }
            return true;
        }
    }
}
