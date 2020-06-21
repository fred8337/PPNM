using System;
using static System.Console;
public class NeuralNetwork
{
    public int hiddenNeurons;
    public vector parameters;
    public vector data;
    public vector labels;
    public Func<double, double> Activation; 
    public Func<double, double> DerActivation; 
    public Func<double, double> IntActivation; 
    public NeuralNetwork(int hiddenNeurons, Func<double, double> activation, Func<double, double> derActivation, Func<double, double> intActivation)
    {
        this.hiddenNeurons=hiddenNeurons;
        parameters = new vector(this.hiddenNeurons*3);
        Activation = activation;
        DerActivation = derActivation;
        IntActivation = intActivation;
    }
    private double relu(double x)
    {
        if(x<=0)
        {
            return 0;
        }
        else
        {
            return x;
        }
    }
    private double gaussian(double x)
    {
        return x*Math.Exp(-Math.Pow(x,2));
    }
    private vector relu(vector x)
    {
        vector res = new vector(x.size);
        for(int i = 0; i<x.size; i++)
        {
            res[i]=relu(x[i]);
        }
        return res;
    }
    private double MSE(double pred, double label)
    {
        return Math.Pow(pred-label,2);
    }
    public double eval(double x)
    {
        double res = 0;
        for(int i = 0; i<hiddenNeurons; i++)
        {
            res += Activation((x-parameters[i*3])/parameters[i*3+1])*parameters[i*3+2];
        }
        return res;
    }
    // public double eval(double x, vector weights)
    // {
    //     vector hold = x*weights;
    //     // hold.print();
    //     hold = relu(hold);
    //     double res = 0;
    //     for(int i = 0; i<hold.size; i++)
    //     {
    //         res+=hold[i];
    //     }
    //     return res;
    // }
    // static Func<vector, double> trainingFunc = delegate(vector x)
    // {
    //     double res = 0;
    //     for(int i = 0; i<data.size;i++)
    //     {
    //         res+=MSE(eval(data[i], x),labels[i]);
    //     }
    //     return res;
    // };
    public void fit(double[] data, double[] labels)
    {
        parameters.print();
        Func<vector, double> trainingFunc = (x) =>
        {
            parameters = x;
            double res = 0;
            for(int i = 0; i<data.Length;i++)
            {
                // parameters.fprint(Console.Error);
                // Error.Write($"{data[i]}\n");
                // Error.Write($"{eval(data[i])}\n");
                res+=MSE(eval(data[i]),labels[i]);
            }
            // Error.Write($"current error is {res/data.Length} \n");
            return res;
        };
        // var guesses = new vector(parameters.size);
        // for(int i = 0;i<guesses.size;i++)
        // {
        //     guesses[i]=1;
        // }
        parameters = qnewton.QNewton(trainingFunc, parameters, 0.01);
        parameters.print();
    }
    public double derivative(double x)
    {
        double res = 0;
        for(int i = 0;i<hiddenNeurons;i++)
        {
            res += parameters[i*3+2]*DerActivation((x-parameters[i*3])/parameters[i*3+1])/parameters[i*3+1];
        }
        return res;
    }
    public double integral(double a, double b)
    {
        double res = 0;
        for(int i = 0;i<hiddenNeurons;i++)
        {
            res += parameters[i*3+2]*IntActivation((b-parameters[i*3])/parameters[i*3+1])*parameters[i*3+1]-parameters[i*3+2]*IntActivation((a-parameters[i*3])/parameters[i*3+1])*parameters[i*3+1];
        }
        return res;
    }
}