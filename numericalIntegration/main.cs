using System;
public static class main
{
    public static int Calls = 0;
    static Func<double,double> F1 = (x) =>
    {
        Calls++;
        return Math.Sqrt(x);
    };
    static Func<double,double> F2 = (x) =>
    {
        Calls++;
        return 4*Math.Sqrt(1-x*x);
    };
    static Func<double,double> F3 = (x) =>
    {
        Calls++;
        return 1/Math.Sqrt(x);
    };
    static Func<double,double> F4 = (x) =>
    {
        Calls++;
        return Math.Log(x)/Math.Sqrt(x);
    };
    public static void Main()
    {
        Console.WriteLine("A)");
        var res1 = Integrator.integrator(F1, 0, 1, 0.001, 0.001);
        Console.WriteLine($"Sqrt(x) from 0 to 1 is {res1} compared to {2.0/3.0} in {Calls} calls");
        
        Calls = 0;
        var res2 = Integrator.integrator(F2, 0, 1, 0.001, 0.001);
        Console.WriteLine($"4sqrt(1-x^2) from 0 to 1 is {res2} compared to {Math.PI} in {Calls} calls");

        Console.WriteLine("B)");
        Calls = 0;
        var res3 = Integrator.clenshaw(F3, 0, 1, 0.001, 0.001);
        Console.WriteLine($"1/sqrt(x) from 0 to 1 is {res3} compared to {2.0} in {Calls} calls");

        Calls = 0;
        var res4 = Integrator.clenshaw(F4, 0, 1, 0.001, 0.001);
        Console.WriteLine($"Log(x)/sqrt(x) from 0 to 1 is {res4} compared to {-4} in {Calls} calls");

        Calls = 0;
        var res5 = Integrator.clenshaw(F2, 0 , 1, 0.000001, 0.000001);
        var curtisCalls = Calls; 
    
        Calls = 0;
        var res6 = quad.o8av(F2, 0, 1, 0.000001, 0.000001);
        var oCalls = Calls;

        Calls = 0;
        var res7 = Integrator.integrator(F2, 0, 1, 0.000001, 0.000001);
        Console.WriteLine($"Adaptive is {res7} in {Calls} calls, compared to Curtis-Clenshaw {res5} in {curtisCalls} calls, compared to o8av {res6} in {oCalls} calls.");
    }
}