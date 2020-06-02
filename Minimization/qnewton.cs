using System;
public static class qnewton
{
    public static int steps = 0;

    // Borrowed from Dmitri
    public static readonly double EPS=1.0/4194304;
    public static vector gradient(Func<vector,double>f, vector x){
        vector g=new vector(x.size);
        double fx=f(x);
        for(int i=0;i<x.size;i++){
            double dx=Math.Abs(x[i])*EPS;
            if(Math.Abs(x[i])<Math.Sqrt(EPS)) dx=EPS;
            x[i]+=dx;
            g[i]=(f(x)-fx)/dx;
            x[i]-=dx;
        }
        return g;
    }
    public static vector QNewton(Func<vector,double> f, vector xstart, double eps)
    {
        int n = xstart.size;
        matrix H = new matrix(n, n);
        H.set_unity();
        var x = xstart;
        double fx;
        double fy;
        vector y;
        while(true)
        {
            steps++;
            vector grad = gradient(f, x);
            var dir = -H*grad;
            fx = f(x);
            double lamb=2;
            vector deltaX;
            while(true)
            {
                lamb/=2;
                deltaX = lamb*dir;
                y=x+deltaX;
                fy = f(y);
                if(lamb<0.02)
                {
                    H.set_unity();
                }
                if(fy<fx+0.0001*deltaX.dot(grad)){break;}
            }
            x = y;
            fx=fy;
            if(deltaX.norm()<eps){break;}
            
            vector gradForUpdate = gradient(f, x);
            var yk = gradForUpdate-grad;
            var vecForUpdate = deltaX-H*yk;
            double denom = (vecForUpdate.dot(yk));
            if(denom>eps)
            {
                H = H + (matrix.outer(vecForUpdate, vecForUpdate))/denom;
            }
        }
        return x;
    }
}