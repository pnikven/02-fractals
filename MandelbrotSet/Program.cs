using System.IO;

namespace MandelbrotSet
{
    class Program
    {
        private const double Step = 0.01;

        static void Main(string[] args)
        {
            var file = new StreamWriter("result.txt",false);
            for (double I = -2; I < 2; I+=Step)
            {
                for (double R = -2; R < 2; R += Step)
                {
                    if(MandelbrotSet.CheckPoint(R,I))
                        file.Write('#');
                    else 
                        file.Write('.');

                }
                file.WriteLine("");
            }
            file.Close();
        }
    }

    class MandelbrotSet
    {
        private const int IterationCount = 100;


        public static bool CheckPoint(double R, double I)
        {
            double cR = R, cI = I;
            for (int i = 0; i < IterationCount; i++)
            {
                if (cR*cR + cI*cI > 4) return false;
                double tR = cR*cR + cI*cI + R;
                double tI = 2 * cR * cI + I;
                cR = tR;
                cI = tI;
            }

            return true;
        }
    }
}
