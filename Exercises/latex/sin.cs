using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
class Sin{
    public static void Main(){
        double a=0,y0=0,y1=1,b=10;
        Func<double, vector, vector> sincos=delegate(double x, vector y){
            var result = new vector(y[1],-y[0]);
            return result;
        };
        vector ya = new vector(0, 1);
        List<double> xs=new List<double>();
        List<vector> ys=new List<vector>();
        vector yb=ode.rk23(sincos,a,ya,b,xs,ys);
	    for(int i=0;i<xs.Count;i++)
		    WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
    }
}