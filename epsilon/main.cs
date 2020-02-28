using static System.Console;
using static System.Math;
using static cmath;
using static complex;
using static Approx;
class main{
    public static void Main(){
       int i = 1;
       while(i+1>i){
           i++; 
       }
       Write($"My max int is {i}, compared to {int.MaxValue} \n");
        i = 0;
        while(i-1<i){
           i--; 
       }
       Write($"My min int is {i}, compared to {int.MinValue} \n");
       double x=1; while(1+x!=1){x/=2;} x*=2;
       Write($"Epsilon for double is {x} compared to {Pow(2,-52)}\n");
       float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
       Write($"Epsilon for float is {y} compared to {Pow(2,-23)}\n");
       int max=int.MaxValue/2;
       float float_sum_up = 1f;
       for(int j = 2; j<max; j++){
           float_sum_up += 1f/j;
       }
       float float_sum_down = 1f/max;
        for(int j = max-1; j>0; j--){
           float_sum_down += 1f/j;
       }
       Write($"{float_sum_up} compared to {float_sum_down}\n");
       double double_sum_up = 1.0;
       for(int j = 2; j<max; j++){
           double_sum_up += 1.0/j;
       }
       double double_sum_down = 1.0/max;
        for(int j = max-1; j>0; j--){
           double_sum_down += 1.0/j;
       }
       Write($"{double_sum_up} compared to {double_sum_down}\n"); //The precision of the float is not enough for the small parts of the sum. It will not converge as function of max. If max becomes large enough all parts will be zero, therefore we could maybe call this convergence.
       
    }
}