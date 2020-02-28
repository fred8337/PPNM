using System;
using static System.Console;
using static System.Math;
class main{
    delegate double myFun(double x);
    double b;
    static Func<double,double> makefun(double y){
        double a;
        a=y;
        // return delegate(double x){
        //     return y;
        // };
        return x=> a;
    }
    static Func<double, Func<double,double>> makemakefun(double y){
        Func<double,Func<double,double>> result = (double x) => (t => x);
        return result;
    }
    static double eval(Func<double,double> f, double x){
        return f(x);
    }
    static double gamma(double z){
        const double inf=System.Double.PositiveInfinity;
        const double nan=System.Double.NaN;
        if(z<0){
            return -PI/Sin(PI*z)/gamma(1+z);
        }
        if(z<1){
            return gamma(z+1)/z;
        }
        if(z>2){
            return gamma(z-1)*(z-1);
        }
        Func<double,double> f = (x)=>Pow(x,z-1)*Exp(-x);
        return quad.o8av(f,0,inf,acc:1e-6,eps:0);
		}
	
    
    public static int Main(){
        const double inf=System.Double.PositiveInfinity;
        double a;
        a = 1;
        Func<double,double> h1 = x=>a;
        a = 2;
        Func<double,double> h2 = x=>a;


        Func<double,double> f = delegate(double x){return x;};
        myFun g = delegate(double x){return x;};
        Write("f({0})={1}\n",9,f(9));
        Func<double,double> f1 = makefun(1);
        Func<double,double> f2 = makefun(2);
        Write($"f1(0)={f1(0)}, f2(0)={f2(0)}\n",f1,f2);
        a = 9;
        Write($"a={a}, h1(0)={eval(h1, 0)}, h2(0)={eval(h2, 0)}\n",f1,f2);
        Func<double,double> e1 = (x)=>Log(x)/Sqrt(x);
        Func<double,double> e2 = (x)=>Exp(-Pow(x,2));
        Func<double,double> e3 = (x)=>Pow(Log(1/x), 1.5);
        Write("e1={0}, compared to {1}\n",quad.o8av(e1,0,1),-4);
        Write("e2={0}, compared to {1}\n",quad.o8av(e2,-inf,inf),Sqrt(PI));
        Write("e3={0}, compared to {1}\n",quad.o8av(e3,0,1),gamma(1.5+1));
        return 0;
    }
}