using System;
using static vector;
using System.Collections.Generic;
public class LeastSquare
{
    public vector c;
    public matrix S;
    public LeastSquare(){}
    public void fit(Func<double, double>[] fs, vector x, vector y, vector dy)
    {
        var n = x.size;
        var m = fs.Length;
        var A = new matrix(n, m);
        var b = new vector(n);
        for(int i=0; i<n; i++)
        {
            b[i]=y[i]/dy[i];
            for(int j=0; j<m; j++)
            {
                A[i, j] = fs[j](x[i])/dy[i];
            }
        }
        var qrData = LinEq.QrGsDecomp(A);
        c = LinEq.QrGsSolve(qrData, b);
        var inverse_R = LinEq.inverse(LinEq.QrGsDecomp(qrData.R));
        S = inverse_R*inverse_R.T;
    }
}