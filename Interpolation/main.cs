using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public static class main
{
    public static void Main()
    {
        var sineData = SinGen(1000);
        var linterData = SinGen(20);
        File.WriteAllLines("sine.txt", sineData.X.Select((x, i) => $"{x} {sineData.Y[i]}"));
        File.WriteAllLines("inter.txt", 
        linterData.X
        .Select((x, i) => new { X = x, index = i })
        .Where(x => x.index % 1 == 0)
        .Select(x => new { X = x.X, Y = Lspline.LInterp(linterData.X, linterData.Y, x.X)})
        .Select(x => $"{x.X} {x.Y}"));
        File.WriteAllLines("integral.txt", 
        linterData.X
        .Select((x, i) => new { X = x, index = i })
        .Where(x => x.index % 1 == 0)
        .Select(x => new { X = x.X, Y = Lspline.LInterpInteg(linterData.X, linterData.Y, x.X)})
        .Select(x => $"{x.X} {x.Y}"));
        Console.WriteLine($"{Lspline.LInterpInteg(linterData.X, linterData.Y, Math.PI)} compared to 2");
    }
    public static Data SinGen(int size)
    {
        double i = 0;
        int j = 0;
        double stepSize = (2.0*Math.PI)/((double) size);
        var sineData = new Data(new double[size], new double[size]);
        while(j<size)
        {
            sineData.X[j] = i;
            sineData.Y[j] = Math.Sin(i);
            i+=stepSize;
            j++;
        };
        return sineData;
    }
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