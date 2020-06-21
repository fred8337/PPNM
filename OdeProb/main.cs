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
    static Func<double,vector,vector> sir(double n, double r, double c)
    {
        return (x,y) =>
        {
            vector result = new vector(3);
                var S = y[0]; 
                var I = y[1];
                result[0] = -I*S/(n*c);
                result[1] = I*S/(n*c) - I/r;
                result[2] = I/r;
                return result;
        };
    }
    public static void Main()
    {
        Console.WriteLine("A) Refer to plot.svg, here u=-u'' is solved and the expected result is sin and cos");
        double a=0;
	    vector ya=new vector(0,1);
	    double b=2.25*Math.PI;
	    double h=0.1,acc=1e-3,eps=1e-3;
        var data = OdeSolver.Driver(F, a, ya, b, h, acc, eps, 1000);
        File.WriteAllLines("Plot.txt", data.Xs
        .Select((x, i) => $"{x} {data.Ys[i][0]} {data.Ys[i][1]}"));
        a=0;
        double r0 = 0;
        double i0 = 700;
        double population = 5500000;
        double s0 = population-r0-i0;
	    ya=new vector(s0, i0, r0);
	    b=120;
	    h=0.1;
        acc=1e-3;
        eps=1e-3;
        Console.WriteLine("B) SIR modelled with parameters fitting for denmark, refer to plot2.svg");
        data = OdeSolver.Driver(sir(population, 8, 3), a, ya, b, h, acc, eps, 1000);
        data.Ys[1].print();
        File.WriteAllLines("Plot2.txt", data.Xs
        .Select((x, i) => $"{x} {data.Ys[i][0]} {data.Ys[i][1]} {data.Ys[i][2]}"));
    }
}