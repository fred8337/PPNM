using System;
public static class Newton
{
    public static vector newton(Func<vector,vector> f, vector x, double epsilon=1e-3, double dx=1e-7)
    {
        vector res = x.copy();
        var n = res.size;
        var J = new matrix(n, n);

        while(true)
        {
            var fx = f(res);
            for(int j = 0; j<n; j++)
            {
                res[j]+=dx;
                var df = f(res)-fx;
                for(int i = 0; i<n; i++)
                {
                    J[i, j] = df[i]/dx;
                }
                res[j]-=dx;
            }
            var J_qr = LinEq.QrGsDecomp(J);
            var Dx = LinEq.QrGsSolve(J_qr, -fx);
            // Dx.print();
            double s=2;
            vector y, fy;
            double comp_norm;
            while(true)
            {
                s/=2;
                y=res+Dx*s;
                fy = f(y);
                comp_norm = fy.norm();
                if(comp_norm<(1-s/2)*comp_norm|s<0.02){break;}
            }
            res=y;
            fx=fy;
            comp_norm = Dx.norm();
            if(comp_norm<dx|comp_norm<epsilon){break;}
            
        }
        return res;
    }
}