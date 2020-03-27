using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
public static class main
{
    public static void Main()
    {
        var time = new double[]{1, 2, 3, 4, 6, 9, 10, 13, 15};
        var activity = new double[]{117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1};
        vector timeVec = new vector(time.Length);
        vector activityVec = new vector(activity.Length);
        vector dyVec = new vector(activity.Length);
        var fs = new Func<double, double>[]{x=>1,x=>x};
        for(int i = 0; i<activity.Length; i++)
        {
            timeVec[i] = time[i];
            activityVec[i] = Math.Log(activity[i]);
            dyVec[i] = activity[i]/20;
        }
        var fitter = new LeastSquare();
        fitter.fit(fs, timeVec, activityVec, dyVec);
        var ExpData = new Data(time, activity);
        File.WriteAllLines("ExpData.txt", ExpData.X.Select((x, i) => $"{x} {ExpData.Y[i]} {dyVec[i]}"));
        File.WriteAllLines("Fit.txt", ExpData.X.Select((x, i) => $"{x} {func(x, Math.Exp(fitter.c[0]), fitter.c[1])}"));
        for (int i = 0; i<fitter.c.size; i++)
        {
            System.Console.WriteLine(fitter.c[i]);
        }
        fitter.S.print();
        System.Console.WriteLine("The half-life is : "+$"{-Math.Log(2)/fitter.c[1]}+-{Math.Abs(-Math.Log(2)/Math.Sqrt(fitter.S[1,1]))}");
    }
    public class Data
    {
        public double[] X;
        public double[] Y;
        public Data(double[] x, double[] y)
        {
            X = x;
            Y = y;
        }
    }
    public static double func(double x, double a, double lamb)
    {
        return a*Math.Exp((lamb*x));
    }
}