using static System.Math;
public struct vector3d{
    private double x, y, z;
    public vector3d(double x, double y, double z){
        this.x=x;
        this.y=y;
        this.z=z;
    }
    public override string ToString(){
        return $"({x}, {y}, {z})";
    }
    public static vector3d operator+(vector3d a, vector3d b){
        vector3d result = new vector3d(0, 0, 0);
        result.x = a.x+b.x;
        result.y = a.y+b.y;
        result.z = a.z+b.z;
        return result;
    }
    public static vector3d operator-(vector3d a, vector3d b){
        vector3d result = new vector3d(0, 0, 0);
        result.x = a.x-b.x;
        result.y = a.y-b.y;
        result.z = a.z-b.z;
        return result;
    }
    public static vector3d operator*(double a, vector3d b){
        vector3d result = new vector3d(0, 0, 0);
        result.x = b.x*a;
        result.y = b.y*a;
        result.z = b.z*a;
        return result;
    }
    public static vector3d operator*(vector3d a, double b){
        return b*a;
    }
    public static double dotProduct(vector3d a, vector3d b){
        double result = a.x*b.x+a.y*b.y+a.z*b.z;
        return result;
    }
    public static double magnitude(vector3d a){
        double result = Sqrt(Pow(a.x, 2)+Pow(a.y, 2)+Pow(a.z, 2));
        return result;
    }
    public static vector3d vectorProduct(vector3d a, vector3d b){
        vector3d result = new vector3d(a.y*b.z-b.y*a.z, -(a.x*b.z-a.z*b.x), a.x*b.y-a.y*b.x);
        return result;
    }
    }