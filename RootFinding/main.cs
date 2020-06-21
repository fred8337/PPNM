using System;
public static class main
{
    static Func<vector,vector> F = delegate(vector x)
    {
        var a = 5;
        var b = 2;
        var res = a*x[0]+b;
	    return new vector(new double[]{res});
    };
    static Func<vector,vector> DRosenbrock = delegate(vector x)
    {
        vector result_vector = new vector(2);
        result_vector[0] = 2*x[0]-2+400*Math.Pow(x[0],3)-400*x[0]*x[1];
        result_vector[1] = 200*x[1]-200*Math.Pow(x[0],2);
        return result_vector;
    };
    Func<double,vector,vector> wave = (x,y)=>
	{ 
		return new vector(y[1], 2*(-1/x-e)*y[0]);
	};
    public static void Main()
    {
        vector guesses = new vector(new double[]{0});
        vector roots = Newton.newton(F, guesses);
        roots.print();
        vector guesses_RosenBrock = new vector(new double[]{0, 0});
        vector roots_RosenBrock = Newton.newton(DRosenbrock, guesses_RosenBrock);
        roots_RosenBrock.print();
    }
}