public static class LinEq
{
    public static Data QrGsDecomp(matrix A)
    {
        int m = A.size2;
        var QrData = new Data(A.copy(), new matrix(m, m));
        for(int i=0; i<m; i++)
        {
            // QrData.Q.print();
            QrData.R[i,i]=QrData.Q[i].norm();
            QrData.Q[i]/=QrData.R[i,i];
            for(int j=i+1; j<m; j++)
            {
                // QrData.Q.print();
                QrData.R[i,j]=QrData.Q[i].dot(QrData.Q[j]);
                QrData.Q[j]-=(QrData.Q[i]*QrData.R[i,j]);
                // QrData.Q.print();
            }
            // QrData.Q.print();
        }
        // QrData.Q.print();
        return QrData;
    }
    
    public static vector QrGsSolve(Data data, vector b)
    {
        b = data.Q.transpose()*b;
        int size = b.size;
        vector y = new vector(size);
        for(int i = size -1;i>=0;i--)
        {
            double res = b[i];
            for(int j = i +1; j<size; j++){
                res -= data.R[i, j]*y[j];
            }
            y[i] = res/data.R[i, i];
        }
        return y;
    }
    public class Data
    {
        public matrix Q, R;
        public Data(matrix q, matrix r)
        {
            Q = q;
            R = r;
        }
    }
}
