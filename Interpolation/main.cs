using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
public static class main{
    public static void Main(){
        Tuple<double[], double[]> data = new Tuple<double[], double[]>(new double[20], new double[20]);  
        data = SinGen();
        Lspline.linterp(data.Item1,data.Item2, 2);
        int length = sizeof(data.Item1);
        for(int i = 0; i<length; i++){
            WriteLine($"{data.Item1[i]} {data.Item2[i]}");
        }
        
    }
    public static Tuple<double[], double[]> SinGen(){
        double i = 0;
        int j = 0;
        double stepSize = 2*PI/(20);
        double[] xs = new double[20];
        double[] ys = new double[20];
        while(i<2*PI){
            xs[j] = i;
            ys[j] = Sin(i);
            i+=stepSize;
            j++;
            };
	    
        return new Tuple<double[], double[]>(xs, ys);
    }
}