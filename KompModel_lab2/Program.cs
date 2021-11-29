using System;
using System.Collections.Generic;
using System.Xml.Linq; 
namespace KompModel_lab2
{
    class Program
    {
        static double f1( double z)
        {
            return 1 + 5 * z;
        }
        static double f2(double t, double x, double y, double z)
        {
           return -(1 - Math.Sin(t) ) * x - y - 3*z;
        }
        static double f3( double x, double z)
        {
            return x - 2 * z;
        }
        static void Main(string[] args)
        {
            double h = 0.05;
            double t0 = 2, tn = 2.5, n = (tn - t0) / h;
            Dictionary<double, double> t = new Dictionary<double, double>();
            Dictionary<double, double> x = new Dictionary<double, double>();
            Dictionary<double, double> y = new Dictionary<double, double>();
            Dictionary<double, double> z = new Dictionary<double, double>();
            t[0] = t0;
            x[0] = 1;
            y[0] = 0;
            z[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                t[i] = t[i - 1] + h ;
                x[i] = x[i - 1] + (h) * f1( z[i-1] );
                y[i] = y[i - 1] + (h) * f2(t[i - 1], x[i - 1], y[i - 1], z[i - 1]);
                z[i] = z[i - 1] + (h) * f3(x[i - 1], z[i - 1]);

            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"t={Math.Round(t[i], 2)} ;  x={Math.Round(x[i], 2)} ;  y={Math.Round(y[i], 2)} ;  z={Math.Round(z[i], 2)}");
            }
        }
    }
}
