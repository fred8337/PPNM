using System;
public static class lu
{
    // public static data luFactor(matrix A)
    // {
    //     matrix U = new matrix(A.size1, A.size1);
    //     matrix L = new matrix(A.size1, A.size1);
    //     L.set_identity();
    //     for(int i = 0;i<A.size1;i++)
    //     {
    //         U[0, i] = A[0, i];
    //     }
    //     double v;
    //     for(int i = 0;i<A.size1-1;i++)
    //     {
            
    //         for(int j = i+1; j<A.size1;j++)
    //         {
    //             v = A[j, i]/U[i, i];
    //             L[j,i] = v;
    //             U[i+1,j]=A[i+1,j]-v*U[i,j];
    //         }
    //     }
    //     return new data(U, L);
    // }
    public static data luFactor(matrix A)
    {
        matrix U = A.copy();
        matrix L = new matrix(A.size1, A.size1);
        L.set_identity();
        double v;
        for(int i = 0;i<A.size1-1;i++)
        {    
            for(int j = i+1; j<A.size1;j++)
            {
                v = U[j, i]/U[i, i];
                L[j,i] = v;
                for(int k = i; k<A.size1;k++)
                {
                    U[j,k]=U[j,k]-v*U[i,k];
                }  
            }
        }
        return new data(U, L);
    }
    public class data
    {
        public matrix U;
        public matrix L;
        public data(matrix u, matrix l)
        {
            U = u;
            L = l;
        }
    }
}