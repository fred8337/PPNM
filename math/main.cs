using static System.Console;
using static System.Math;
using static cmath;
using static complex;
class main{
    public static void Main(){
        complex a = sqrt(2);
        complex e = E;
        complex i = new complex(0, 1);
        complex b = e.pow(i);
        complex c = e.pow(i*PI);
        complex d = i.pow(i);
        complex f = sin(i*PI);
        Write(a.ToString()+"\n");
        Write(b.ToString()+"\n");
        Write(c.ToString()+"\n");
        Write(d.ToString()+"\n");
        Write(f.ToString()+"\n");
    }
}