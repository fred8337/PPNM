using static System.Console;
using static System.Math;


public static class Lspline{
    public static double linterp(vector x, vector y, double z){
        int i=0, j=x.size-1;
        while (j-i>1){
            int m=(i+j)/2; 
            if (z>x[m]) i=m;
            else j=m; 
        }
        return y[i]+(y[i+1]-y[i])/(x[i+1]-x[i])*(z-x[i]);
    }
    public static double linterpInteg(vector x, vector y, double z){
        double result = 0;
        double p;
        for(int i=0;i<x.size-1;i++){
            result+=x[i];
        }
        return result;
    }
}