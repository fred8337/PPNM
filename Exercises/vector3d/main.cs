using static System.Console;
using static vector3d;
public class main{
    public static void Main(){
        vector3d a = new vector3d(1, 2, 3);
        vector3d b = new vector3d(4, 5, 6);
        WriteLine("The vectors are: "+a.ToString()+" and "+b.ToString());
        vector3d c = a+b;
        WriteLine("Their sum is: "+c.ToString());
        vector3d d = a-b;
        WriteLine("Their difference is: "+d.ToString());
        double e = dotProduct(a, b);
        WriteLine("Their dot is: "+e.ToString());
        vector3d f = vectorProduct(a, b);
        WriteLine("Their cross is: "+f.ToString());
        double g = magnitude(a);
        double h = magnitude(b);
        WriteLine("Their magnitudes are: "+g.ToString()+" and "+h.ToString());
    }
}