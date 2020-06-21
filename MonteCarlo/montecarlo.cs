using System;
public static class montecarlo
{
    public static data plainMC(Func<vector,double> f, double[] a, double[] b, int N)
    {
        Func<double[], double[], vector> randomHelper = delegate(double[] x, double[] y)
        {
            var rand = new Random();
            vector res = new vector(x.Length);
            for(int i = 0;i<x.Length;i++)
            {
                res[i] = x[i]+rand.NextDouble()*(y[i]-x[i]);
            }
            return res;
        };
        double volume = 1;
        for(int i = 0;i<a.Length;i++)
        {
            volume*=b[i]-a[i];
        }
        double sum = 0;
        double sum2 = 0;
        for(int i = 0;i<N;i++)
        {
            double fx = f(randomHelper(a,b));
            sum += fx;
            sum2 += fx*fx;
        }
        double mean = sum/N;
        double sigma = Math.Sqrt(sum2/N-mean*mean);
        double SIGMA = sigma/Math.Sqrt(N);
        return new data(mean*volume, SIGMA*volume);
    }
    public class data
    {
        public double Mean;
        public double Sigma;
        public data(double mean, double sigma)
        {
            Mean = mean;
            Sigma = sigma;
        }
    }
}