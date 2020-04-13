using System;
public static class Integrator
{
    public static double integrator(Func<double,double> f, double a, double b, double delta, double e)
    {
        double f2 = f(a+((2*(b-a))/6));
        double f3 = f(a+((4*(b-a))/6));
        int recs = 0;
        return helper(f, a, b, delta, e, f2, f3, recs);
                
    }
    private static double helper(Func<double,double> f, double a, double b, double delta, double e, double f2, double f3, int recs)
    {
        double f1 = f(a+((b-a)/6));
        double f4 = f(a+((5*(b-a))/6));
        double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
        double q = (f1+f2+f3+f4)/4*(b-a);
        double err = Math.Abs(q-Q);
        if (err < delta+e*Math.Abs(Q)) return Q;
        else 
            return helper(f,a,(a+b)/2,delta/Math.Sqrt(2),e, f1, f2, recs + 1)
            +helper(f,(a+b)/2,b,delta/Math.Sqrt(2),e, f3, f4, recs + 1);    
    }
    public static double clenshaw(Func<double,double> f, double a, double b, double delta, double e)
    {
        var aTrans = Math.Acos(a);
        var bTrans = Math.Acos(b);
        Func<double,double> fTrans = (x) => f(Math.Cos(x))*Math.Sin(x);
        return -integrator(fTrans, aTrans, bTrans, delta, e);
    }
}