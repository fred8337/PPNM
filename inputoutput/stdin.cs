using System;
class stdin{
    static int Main(){
        string s;
        System.IO.TextReader stdin = System.Console.In;
        System.IO.TextWriter stdout = System.Console.Out;
        System.IO.TextWriter stderr = System.Console.Error;
        System.IO.StreamReader inputfile = new System.IO.StreamReader("input.txt");
        System.IO.StreamWriter outputfile = new System.IO.StreamWriter("output.txt", append:false);
        
        do{
            s = Console.ReadLine();  
            if(s==null){
                break;
            }
            string[] words=s.Split(' ',',','\t');
            foreach(string word in words){
                double x = double.Parse(s);
                stdout.WriteLine("{0} {1} {2}",x,Math.Sin(x),Math.Cos(x));
                stderr.WriteLine("{0} {1} {2}",x,Math.Sin(x),Math.Cos(x));
                outputfile.WriteLine("{0} {1} {2}",x,Math.Sin(x),Math.Cos(x));
            }
            
        
        }
        while(true);
        inputfile.close();
        outputfile.close();
        return 0;
    }
}