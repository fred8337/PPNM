using static System.Console;
using static System.Math;
class main{
    string s = "old string\n";
    int i = 666;
    static int Main(){
        double x=1.23;
        int nmax=100;
        string s ="helloæøå\n";
        {
            double y = 0;
        }
        Write(s);
        int two = 2;
        int one =1;
        if(two>one){
            Write("2>1\n");
        }
        else{
            Write("S for static\n");
        }
        for(int i =0; i<10;i++){
            Write($"i={i}\n");
        }
        Write("pi={0:f2}\n",PI);
        while(false);{}
        return 0;
    }
} 