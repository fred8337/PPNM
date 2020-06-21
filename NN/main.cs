using System;
using System.Linq;
using System.IO;
public static class main
{
    public static void Main()
    {
        
        Func<double, double> sin = delegate(double x)
        {
            return Math.Sin(x);
        };
        Func<double, double> gaussianDer = delegate(double x)
        {
            return Math.Exp(-x*x)-2*x*x*Math.Exp(-x*x);
        };
        Func<double, double> gaussian = delegate(double x)
        {
            return x*Math.Exp(-Math.Pow(x,2));
        };
        Func<double, double> gaussianInt = delegate(double x)
        {
            return -Math.Exp(-Math.Pow(x,2))/2;
        };
        var model = new NeuralNetwork(25, gaussian, gaussianDer, gaussianInt);
        int n = 50;
        double[] data = new double[n];
        double[] labels = new double[n];
        double step = 2*Math.PI/n;
        for(int i=0;i<data.Length;i++)
        {
            data[i]=i*step;
            labels[i]=sin(i*step);
        }
        for(int i=0;i<model.hiddenNeurons;i++)
        {
            model.parameters[3*i+0]=2*i/(model.hiddenNeurons-1)-1;
            model.parameters[3*i+1]=1;
            model.parameters[3*i+2]=1;
	    }

        model.fit(data, labels);
        File.WriteAllLines("Plot.txt", data
        .Select((x, i) => $"{data[i]} {labels[i]}"));
        int multiplier = 3;
        double[] dataInter = new double[multiplier*n];
        double[] labelsInter = new double[multiplier*n];
        double[] derivInter = new double[multiplier*n];
        step = 2*Math.PI/(n*multiplier);
        for(int i=0;i<dataInter.Length;i++)
        {
            dataInter[i]=i*step;
            labelsInter[i]=model.eval(dataInter[i]);
            derivInter[i]=model.derivative(dataInter[i]);
        }
        File.WriteAllLines("Plot2.txt", dataInter
        .Select((x, i) => $"{dataInter[i]} {labelsInter[i]} {derivInter[i]}"));
        var integral = model.integral(0 ,1);
        Console.WriteLine($"integral from 0 to 1 of sinus is {integral} compared to 0.4596976941318603");
    }
}