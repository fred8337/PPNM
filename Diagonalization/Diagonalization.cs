using System;
public static class Diagonalization
{
    public static Data jacobi(matrix Aarg)
    {
        var size = Aarg.size1;
        var A = Aarg.copy();
        var e = new vector(size);
        matrix V = new matrix(size, size);
        V.set_identity();
        bool changed;
        int sweeps=0, n=size;
        for(int i = 0;i<n;i++)
        {
            e[i] = Aarg[i, i];
        }
        do{
            changed=false;
            sweeps++;
            int p,q;
            for(p=0;p<n;p++)
            {
                for(q=p+1;q<n;q++)
                {
                    double app = e[p];
                    double aqq = e[q];
                    double apq = A[p,q];
                    double phi = 0.5*Math.Atan2(2*apq, aqq-app);
                    double c = Math.Cos(phi);
                    double s = Math.Sin(phi);
                    double appl = c*c*app-2*s*c*apq+s*s*aqq;
                    double aqql = s*s*app+2*s*c*apq+c*c*aqq;
                    if(appl!=app || aqql!=aqq){
                        changed = true;
                        e[p] = appl;
                        e[q] = aqql;
                        A[p,q] = 0.0;
                        for(int i=0;i<p;i++)
                        {
                            double aip=A[i, p];
                            double aiq=A[i, q];
                            A[i, p]=c*aip-s*aiq;
                            A[i, q]=c*aiq+s*aip;
                        }
                        for(int i=p+1;i<q;i++)
                        {
                            double api=A[p, i];
                            double aiq=A[i, q];
                            A[p, i]=c*api-s*aiq;
                            A[i, q]=c*aiq+s*api;
                        }
                        for(int i=q+1;i<n;i++)
                        {
                            double api = A[p, i];
                            double aqi = A[q, i];
                            A[p, i] = c*api-s*aqi;
                            A[q, i] = c*aqi+s*api;
                        }
                        for(int i = 0; i<n; i++)
                        {
                            double vip = V[i, p];
                            double viq = V[i, q];
                            V[i, p]=c*vip-s*viq;
                            V[i, q]=c*viq+s*vip;
                        }
                    }
                }
            }
        }
        while(changed);
        return new Data(V, e);
    }
    public class Data
    {
        public matrix V;
        public vector E;
        public Data(matrix v, vector e)
        {
            V = v;
            E = e;
        }
    }
}