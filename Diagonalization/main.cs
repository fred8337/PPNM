using System;
public static class main
{
    public static void Main()
    {

        int n=20;
        double s=1.0/(n+1);
        matrix H = new matrix(n,n);
        for(int i=0;i<n-1;i++)
        {
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,n-1,n-1,-2);
        matrix.scale(H,-1/s/s);

        
        var returnVals = Diagonalization.jacobi(H);
        var V = returnVals.V;
        var eigenvals = returnVals.E;

        for (int k=0; k < n/3; k++)
        {
            double exact = Math.PI*Math.PI*(k+1)*(k+1);
            double calculated = eigenvals[k];
            Console.WriteLine($"{k} {calculated} {exact}");
        }
        var A = genSym(5);
        A.print();
        var returnValsA = Diagonalization.jacobi(A);
        var D = returnValsA.V.T*A*returnValsA.V;
        D.print();
        returnValsA.E.print();
        
        A = genSym(100);
        var timing = DateTime.Now;
        Diagonalization.jacobi(A);
        Console.WriteLine($"The time for diagonalization of size 100 matrix was: {DateTime.Now.Subtract(timing)}");
        A = genSym(200);
        timing = DateTime.Now;
        Diagonalization.jacobi(A);
        Console.WriteLine($"The time for diagonalization of size 200 matrix was: {DateTime.Now.Subtract(timing)}");
        }
    public static matrix genSym(int size)
    {
        var res = new matrix(size, size);
        Random fixRand = new Random(0);
        for(int i = 0; i<size; i++)
        {
            for(int j = 0; j<size; j++)
            {   
                var number = fixRand.NextDouble();
                res[i,j] = number;
                res[j,i] = number;
            }
        }
        return res;
    }
}