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

        
    
        public static int FindDigit(string equation)
        {
            // Add your code here.
            int result=-1;//to return
            String[] arrayofnumbers=equation.Split('*','=');//stores numbers 

            //detection of questionmark and then proceed to computation
            if(arrayofnumbers[0].Contains('?')){
                result=Compute(arrayofnumbers,0);
            }else if(arrayofnumbers[1].Contains('?')){
                result=Compute(arrayofnumbers,1);
            }else{
                result=Compute(arrayofnumbers,2);
            }

            return result;
        }

     public static int Compute(String[] arrayofnumbers,int tofind){//analyse the number and compute
         double multiplier1,multiplier2,multiplicationresult;
         int result=0;
          if(tofind==0){//0 means multiplier1 has to be found
               multiplier2=Convert.ToDouble(arrayofnumbers[1]);
               multiplicationresult=Convert.ToDouble(arrayofnumbers[2]);
               multiplier1=multiplicationresult/multiplier2;

              result=Compare(multiplier1,arrayofnumbers[0]);

          }else if(tofind==1){
              multiplier1=Convert.ToDouble(arrayofnumbers[0]);
              multiplicationresult=Convert.ToDouble(arrayofnumbers[2]);
              multiplier2=multiplicationresult/multiplier1;

              result=Compare(multiplier2,arrayofnumbers[1]);

          }else{
              multiplier1=Convert.ToDouble(arrayofnumbers[0]);
              multiplier2=Convert.ToDouble(arrayofnumbers[1]);
              multiplicationresult=multiplier1*multiplier2;

              result=Compare(multiplicationresult,arrayofnumbers[2]);
          }

      return result;
     }

     public static int Compare(double computedvalue,String actual){//analyse computed result with given value
            int result;
            String computed=computedvalue.ToString();//conversion to String for comparison

            int indexOfmark=actual.IndexOf("?");
            String actualmodified =actual.Replace('?',computed[indexOfmark]);//replacing the question mark

            int check=actualmodified.CompareTo(computed);//comparison
             if(check==0)//for true
              {
                result=computed[indexOfmark]-'0';//getting the answer from string by converting to intege
               }else{
                    result=-1;//return -1 if not same
                     }
                    
                 
          return result;
         }

    }
}
