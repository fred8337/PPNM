using System;
using System.IO;
using System.Linq;
public static class main
{
    static Func<vector, double> rosenbrock = delegate(vector x)
    {
        double result = Math.Pow(1-x[0], 2)+100*Math.Pow((x[1]-Math.Pow(x[0], 2)), 2);
        return result;
    };
    static Func<vector, double> himmelblau = delegate(vector x)
    {
        double result = Math.Pow(Math.Pow(x[0], 2)+x[1]-11, 2)+Math.Pow(x[0]+Math.Pow(x[1], 2)-7, 2);
        return result;
    };
    static Func<vector, double> breitWigner = delegate(vector x)
    {
        double result = x[3]/(Math.Pow(x[0]-x[1],2)+Math.Pow(x[2],2)/4);
        return result;
    };
    static Func<vector, double> deviation = delegate(vector x)
    {
        double res = 0;
        int n = Es.Length;
        for(int i = 0;i<n;i++)
        {
            res+=Math.Pow(breitWigner(new vector(new double[]{Es[i], x[0], x[1], x[2]}))-Crosss[i], 2);
        }
        return res;
    };
    public static double[] Es = new double[100];
    public static double[] Crosss = new double[100];
    public static double[] Errors = new double[100];
    public static void Main()
    {
        Console.WriteLine("A)");
        vector guesses = new vector(new double[]{0, 0});
        int before = qnewton.steps;
        var res = qnewton.QNewton(rosenbrock, guesses, 0.000001);
        int after = qnewton.steps;
        res.print($"Found minimum of Rosenbrock in {after-before} steps: ");
        before = qnewton.steps;
        var res2 = qnewton.QNewton(himmelblau, guesses, 0.000001);
        after = qnewton.steps;
        res2.print($"Found minimum of Himmelblau in {after-before} steps: ");


        Console.WriteLine("B)");
        var data = File.ReadAllLines("/home/fred8337/PPNM/PPNM/Minimization/data.txt");
        var size = data.Length;
        
        var splitted_data = data.Select(x => x.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries));

        int i = 0;
        foreach (var line in splitted_data)
        {   
            // Console.WriteLine(line[1]);
            Es[i]=double.Parse(line[0]);
            Crosss[i]=double.Parse(line[1]);
            Errors[i]=double.Parse(line[2]);
        }
        
        guesses = new vector(new double[]{125, 0.005, 1});
        before = qnewton.steps;
        var res3 = qnewton.QNewton(deviation, guesses, 0.00001);
        after = qnewton.steps;
        res3.print($"Found minimum of Deviation in {after-before} steps: ");
    }
}