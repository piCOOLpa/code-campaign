using System;

namespace recursion
{
    class Program
    {
        public static int FindFactorial_iteratively(int num)
        {
            int factorial = 1;

            if (num < 2 )
            {
                return factorial;
            }
            else
            {
                for(int index = 2; index <= num; ++index)
                {
                    factorial *= index;
                }
            }
            return factorial;
        }

        public static int FindFactorial_recursively(int num)
        {
            int factorial = 1;
           
            if (num < 2 )
            {
                return factorial;
                // base case  
            }
            
            else
            
            {
                //Console.WriteLine(num);
                factorial = num  * FindFactorial_recursively(--num);
                // F(5) --> F(4) --> F(3) --> F(2) -->F(1)        function call 
                // 120  <--  24  <--  6   <--  2   <--  1         function value

                // |F(6)| F(5) | F(4) | F(3) | F(2) | F(1) |           call-stack

            }

            return factorial; 

        }
        static void Main(string[] args)
        {
            Console.Write("enter a number : ");
            Console.WriteLine("factorial value of input no : " + FindFactorial_recursively(Convert.ToInt32(Console.ReadLine())));
            Console.ReadLine();
        }
    }
}
