using System;
using System.Linq;
public static class main
{
    public static void Main()
    {
        // Random fixRand = new Random(0);
        // matrix A = new matrix(6, 4);
        // for(int i = 0; i < A.size1; i++)
        // {
        //     for(int j = 0; j < A.size2; j++)
        //     {
        //         A[i, j] = fixRand.NextDouble();
        //     }
        // }
        // A.print();
        // var data = LinEq.QrGsDecomp(A);
        // data.Q.print();
        // data.R.print();
        // var qtq = data.Q.transpose()*data.Q;
        // qtq.print();
        // var Ares = data.Q*data.R;
        // Ares.print();

        Random fixRand = new Random(0);
        matrix A = new matrix(5, 5);
        vector B = new vector(5);
        for(int i = 0; i < A.size1; i++)
        {
            for(int j = 0; j < A.size2; j++)
            {
                A[j][i] = fixRand.NextDouble();
            }
        }
        for(int i = 0; i < B.size; i++)
        {
            B[i] = fixRand.NextDouble();
        }
        A.print();
        B.print();
        var data = LinEq.QrGsDecomp(A);
        data.Q.print();
        data.R.print();
        var res = LinEq.QrGsSolve(data, B);
        res.print();
        var check = A*res;
        check.print();
        }
}