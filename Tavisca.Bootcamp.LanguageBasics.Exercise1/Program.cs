using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
      class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int GetResult(String obtained,String given){//method to compare strings for corretness and get final reslut
            int toreturn;
            if(obtained.Length!=given.Length)//check for equal length 
                 toreturn=-1;
                 else{
                     int temp=given.IndexOf("?");
                     String finalgiven=given.Replace('?',obtained[temp]);
                     int check=finalgiven.CompareTo(obtained);
                     if(check==0)//for true
                     {
                         toreturn=obtained[temp]-'0';
                     }else{
                         toreturn=-1;
                     }
                 }
          return toreturn;
         }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int star,equal,questionmark;//for storing index position in String of symbols
            int result=-1;//to return
            String obtained,given; 
            double a,b,c;//to store numbers as a*b=c
            star=equation.IndexOf("*");
            equal=equation.IndexOf("=");
            questionmark=equation.IndexOf("?");
            
            if(questionmark>equal){//if questionmark mark on RHS
                 a=Convert.ToDouble(equation.Substring(0,star));
                 b=Convert.ToDouble(equation.Substring(star+1,equal-star-1));
                 c=a*b;
                  obtained=c.ToString();
                  given=equation.Substring(equal+1);
                 result=GetResult(obtained,given);
            }else{
              if(questionmark<star){//if question mark on first number
                 b=Convert.ToDouble(equation.Substring(star+1,equal-star-1));
                 c=Convert.ToDouble(equation.Substring(equal+1));
                 a=c/b;
                  obtained=a.ToString();
                  given=equation.Substring(0,star);
                 result=GetResult(obtained,given);
              }else{//if question mark on second number
                 a=Convert.ToDouble(equation.Substring(0,star));
                 c=Convert.ToDouble(equation.Substring(equal+1));
                 b=c/a;
                  obtained=b.ToString();
                  given=equation.Substring(star+1,equal-star-1);
                 result=GetResult(obtained,given);
              }
            }

            return result;
        }
    }
}
