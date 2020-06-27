/* 
    given a string : aabc
    
    (aa) ----> treated as a single group = [x].

    xbc
    xcb
    bxc
    bcx
    cxb
    cbx
    
    1. lexographical order maintained.
    2. lexographical order not-maintained.
       
    1. find permutations with swap() of the characters.

 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace recursion
{
    class Program
    {
        public static char[] swap_the_characters(char[] S, int index, int level)
        {
            char temp = S[index];
            S[index] = S[level];
            S[level] = temp;
            return S;
        }
        public static void FindPermutations_usingswap_optimized (char[] S, int level)
        {

            if (level == S.Length)
            {
                // hit the base case : one complete arrangememt of the characters reached. reached the maximum level
                // print the char array.
                foreach (char s in S)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
                return;
            }
            else
            {
                for (int index = level; index < S.Length; index++)
                {
                    if (level == index || S[level] != S[index])
                    {
                        //swap the character at index position with the char at level position.
                        S = swap_the_characters(S, index, level);

                        // recurse to solve the sub-problem.
                        FindPermutations_usingswap_optimized(S, level + 1);
                        // O( n * n!) -----> Time Complexity 
                        //  length of the string.

                        // backtrack 
                        /*
                           
                            * 1.swap the character variables to restore the original string    [ restore the string to original]
                           
                        */
                        S = swap_the_characters(S,  level , index);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<char> permuted_string = new List<char>();
            Console.Write("enter a string : ");
            string S = Console.ReadLine();
            char[] S_char = S.ToCharArray();
            Array.Sort<char>(S_char);
            Console.WriteLine("permutations of the given string  are :");
            FindPermutations_usingswap_optimized(S_char, 0);
            Console.ReadLine();
        }

    }
}

