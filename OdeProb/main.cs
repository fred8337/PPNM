using System;
using System.Collections.Generic;
using static vector;
using System.Linq;
using System.IO;
public static class main
{
    static Func<double,vector,vector> F = delegate(double x, vector y)
    {
	    return new vector(y[1],-y[0]);
    };
    public static void Main()
    {
        double a=0;
	    vector ya=new vector(0,1);
	    double b=2.25*Math.PI;
	    double h=0.1,acc=1e-3,eps=1e-3;
        var data = OdeSolver.Driver(F, a, ya, b, h, acc, eps, 1000);
        File.WriteAllLines("Plot.txt", data.Xs
        .Select((x, i) => $"{x} {data.Ys[i][0]} {data.Ys[i][1]}"));
    }
}