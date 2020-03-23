using static System.Console;
using static System.Math;


public static class Lspline{
    public static double LInterp(vector x, vector y, double z){
        int i=0, j=x.size-1;
        while (j-i>1){
            int m=(i+j)/2; 
            if (z>x[m]) i=m;
            else j=m; 
        }
        return y[i]+(y[i+1]-y[i])/(x[i+1]-x[i])*(z-x[i]);
    }
    public static double LInterpInteg(vector x, vector y, double z){
        double result = 0;
        int i = 0;
        while(z>x[i+1]){
            result += y[i]*(x[i+1]-x[i])+(1/2)*((y[i+1]-y[i])/(x[i+1]-x[i]))*(x[i+1]-x[i])*(x[i+1]-x[i]);
            i++;
        }
        result += y[i]*(z-x[i])+(1/2)*((y[i+1]-y[i])/(x[i+1]-x[i]))*(z-x[i])*(z-x[i]);
        return result;
    }
}