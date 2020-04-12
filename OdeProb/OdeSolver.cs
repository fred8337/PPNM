using System;
using System.Collections.Generic;
public static class OdeSolver
{
    static vector rkstep12(
	Func<double,vector,vector> f, /* the right-hand-side of dydt=f(t,y) */
	double t,                     /* the current value of the variable */
	vector yt,                    /* the current value y(t) of the sought function */
	double h,                     /* the step to be taken */
	vector err                    /* output: error estimate dy */
    )
    {
        var yh = new vector(yt.size);
        int n = yt.size;
        var k0 = f(t, yt);
        var hold = new vector(n);

        for(int i = 0;i<n;i++)
        {
            hold[i] = yt[i]+k0[i]*h/2;
        }

        var k12 = f(t+h/2, hold);

        for(int i = 0;i<n;i++)
        {
            yh[i] = yt[i]+k12[i]*h;
        }

        for(int i = 0;i<n;i++)
        {
            err[i] = (k0[i]-k12[i])*h/2;
        }
        return yh;
    }

    public static Data Driver(
	Func<double,vector,vector> f, /* right-hand-side of dydt=f(t,y) */
	double a,                     /* the start-point a */
	vector y,                     /* y(a) */
	double b,                     /* the end-point of the integration */
	double h,                      /* initial step-size */
	double acc,                   /* absolute accuracy goal */
	double eps,                   /* relative accuracy goal */
    int maxSteps
    )
    {
        int k = 0;
        List<double> xlist = new List<double>(maxSteps);
        List<vector> ylist = new List<vector>(maxSteps);
        xlist.Add(a);
        ylist.Add(y);
        double s, normy, err, tol = 0;
        var dy = new vector(y.size);
        while(xlist[k]<b)
        {
            var x = xlist[k];
            if(x+h>b)
            {
                h=b-x;
            }
            
            y = rkstep12(f, x, y, h, dy);
            s = 0;
            for(int i=0;i<dy.size;i++)
            {
                s+=dy[i]*dy[i];
            }
            err = Math.Sqrt(s);
            s = 0;
            for(int i=0;i<dy.size;i++)
            {
                s+=y[i]*y[i];
            }
            normy=Math.Sqrt(s);
            tol = (normy*eps+acc)*Math.Sqrt(h/(b-a));
            if(err<tol)
            {
                xlist.Add(x+h);
                k++;
                ylist.Add(y);
            }
            if(err > 0)
            {
                h*=Math.Pow(tol/err, 0.25)*0.95;
            }
            else
            {
                h*=2;
            }
        }
        return new Data(xlist, ylist);
    }
    public class Data
    {
        public List<double> Xs;
        public List<vector> Ys;
        public Data(List<double> xs, List<vector> ys)
        {
            Xs = xs;
            Ys = ys;
        }
    }
}