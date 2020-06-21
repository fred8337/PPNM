using System;
using System.Linq;
using System.IO;
public static class main
{
    public static void Main()
    {
        Func<vector, double> first = delegate(vector x)
        {
            return Math.Sin(x[0]);
        };
        Func<vector, double> second = delegate(vector x)
        {
            return x[0]+x[1]+x[2];
        };
        Func<vector, double> third = delegate(vector x)
        {
            return 1/(1-Math.Cos(x[0])*Math.Cos(x[1])*Math.Cos(x[2]))*(1/Math.Pow(Math.PI, 3));
        };
        Console.WriteLine("A)");
        var res = montecarlo.plainMC(first, new double[]{0}, new double[]{1}, 100000);
        Console.WriteLine($"{res.Mean} {res.Sigma}");
        var res2 = montecarlo.plainMC(second, new double[]{0, 0 ,0}, new double[]{1, 1, 1}, 100000);
        Console.WriteLine($"{res2.Mean} {res2.Sigma}");
        var res3 = montecarlo.plainMC(third, new double[]{0, 0 ,0}, new double[]{Math.PI, Math.PI, Math.PI}, 1000000);
        Console.WriteLine($"{res3.Mean} {res3.Sigma}");
        Console.WriteLine("B) Refer to the plot");
        int n = 100;
        double[] xs = new double[n];
        double[] ys = new double[n];
        double[] es = new double[n];
        double[] expected = new double[n];
        var step = Math.Pow(10, 6)/n;
        for(int i = 1;i<xs.Length;i++)
        {
            xs[i] = step*i;
            ys[i] = montecarlo.plainMC(first, new double[]{0}, new double[]{1}, Convert.ToInt32(xs[i])).Mean;
            es[i] = Math.Abs(0.4596976941318603-ys[i]);
            expected[i] = 1/Math.Sqrt(xs[i]);
        }
        File.WriteAllLines("error.txt", xs.Select((x, i)=> $"{xs[i]} {ys[i]} {es[i]} {expected[i]}"));
    }
}