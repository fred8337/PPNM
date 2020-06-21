using System;
using System.Linq;
public static class main
{
    public static void Main()
    {
        
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


        Console.WriteLine("Testing A)");
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
        Console.WriteLine("The random Square matrix A");
        A.print();
        Console.WriteLine("The random Vector B for the Linear system Ax=B");
        B.print();
        var data = LinEq.QrGsDecomp(A);
        Console.WriteLine("The matrix Q");
        data.Q.print();
        Console.WriteLine("The matrix R");
        data.R.print();
        var res = LinEq.QrGsSolve(data, B);
        Console.WriteLine("Solution to the system QRx=b");
        res.print();
        var check = A*res;
        Console.WriteLine("Ax=b, should be equal to the random vector B");
        check.print();
        // Random fixRand = new Random(0);
        Console.WriteLine("Testing B)");
        matrix Aforinverse = new matrix(5, 5);
        for(int i = 0; i < Aforinverse.size1; i++)
        {
            for(int j = 0; j < Aforinverse.size2; j++)
            {
                Aforinverse[i, j] = fixRand.NextDouble();
            }
        }
        Console.WriteLine("Random square matrix A for inversion");
        Aforinverse.print();
        var dataB = LinEq.QrGsDecomp(Aforinverse);
        var Bforinverse = LinEq.inverse(dataB);
        var Cforinverse = Aforinverse*Bforinverse;
        Console.WriteLine("AA^-1 = I");
        Cforinverse.print();

    }
}