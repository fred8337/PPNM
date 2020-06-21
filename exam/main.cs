using System;
public static class main
{
    public static void Main()
    {
        var hess = genHessenberg(5, 2);
        Console.WriteLine("Randomly generated upper Hessenberg matrix. Be warned, the algorithm from the paper was incorrect, and will only work for matrices with same properties as their example. This is thus a different algorithm than the one I was asked to implement because Mono does not support .NET 3.0, array slicing is not supported, and the algorithm looks like O(n^3), but would be O(N^2+k) in .NET 3.0..");
        hess.print();
        var res = lu.luFactor(hess);
        Console.WriteLine("U");
        res.U.print();
        Console.WriteLine("L");
        res.L.print();
        var test = res.L*res.U;
        Console.WriteLine("LU");
        test.print();
    }
    public static matrix genHessenberg(int size, int miss)
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
        int count = 1;
        for(int i = size-miss; i<size;i++)
        {
            
            for(int j = 0; j<count;j++)
            {
                res[i,j]=0;
            }
            count++;
        }
        return res;
    }
}