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

namespace recursion
{
    class Program
    {
        public static void FindPermutations_lexographical(char[] S, int level, List<char> permuted_string)
        {

        }
        public static void FindPermutations_usingswap(char[] S , int level  , List<char> permuted_string )
        {
            
            if (level == S.Length)
            {
                // hit the base case : one complete arrangememt of the characters reached. reached the maximum level
                // print the permuted string in the console.
                foreach(char s in permuted_string)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
                return;
            }
            else
            {
                for (int i = level; i < S.Length; i++ )
                {
                    if ( level == i  || S[level] != S[i] )
                    {
                        // swap the level 0 character with all possible characters in the string.
                        char temp = S[level];
                        S[level] = S[i];
                        S[i] = temp;

                        // build the arrangement , put the character in the List
                        permuted_string.Add(S[level]);

                        // recurse to solve the sub-problem.
                        FindPermutations_usingswap(S, level + 1, permuted_string);
                        // O( n * n!) -----> Time Complexity 
                        //  length of the string.

                        // backtrack 
                        /*
                            * 1 decrease the level value                                       [ restore the level]
                            * 2.swap the character variables to restore the original string    [ restore the string to original]
                            * 3.remove the charcter at the level index                         [remove the character at the index level]
                        */

                        temp = S[level];
                        S[level] = S[i];
                        S[i] = temp;

                        permuted_string.RemoveAt(level);
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
            FindPermutations_usingswap(S_char, 0, permuted_string);
            Console.ReadLine();
        }
    }
}
