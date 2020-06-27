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
        public static void FindPermutations_lexographical(List<char> unique_string ,List<int> char_frequency, char[] permutation_arrangement , int level , int string_length)
        {
            sif (level == string_length)
            {
                 // hit the base case : one complete arrangememt of the characters reached. reached the maximum level
                //  print the permuted string in the console.

               foreach (char S in permutation_arrangement)
                {
                    Console.Write(S);
                }
                Console.WriteLine();
                return;
            }
            else
            {
                for (int i = 0; i < unique_string.Count; i++ )
                {
                    // iterate for the unique characters from the left to the right in the string.
                   
                   if (char_frequency[i] == 0 )
                    {
                        //  check if the frequency of the character is zero.
                        //  character at the given index is completely exhausted , move to the next character.
                        continue;
                    }
                    else
                    {
                        // change the state of the recursion.

                        permutation_arrangement[level] = unique_string[i];           // add the character at the level.
                        char_frequency[i] -= 1;                                     // decrement the count for the character used at the level.
                        FindPermutations_lexographical(unique_string, char_frequency, permutation_arrangement, level + 1 , string_length);

                        // backtrack to the original state
                        permutation_arrangement[level] = ' ';
                        char_frequency[i] += 1;
                        

                    }
                }
            }
        }
       
        static void Main(string[] args)
        {
            
            char[] permuted_string  = new char[] { ' ' , ' ' , ' ' , ' '};                                        // char list containing the string char.
            List<char> unique_string = new List<char>();                 //  char list contains only unique char in the string.
            List<int> unique_string_frequency = new List<int>();        //   integer list containing the frequency count of the unique char in the string

            Console.Write("enter a string : ");

            string S = Console.ReadLine();                              // read the string input from user.
            int string_length = S.Length;
            char[] S_char = S.ToCharArray();                           // converts  the string to char array. 


            Array.Sort<char>(S_char);
                                                                        // sort the array.

            SortedDictionary<char, Int32>  unique_string_char   = new SortedDictionary<char, int>();
            // dictionay to store the frequency of each unique char in the string

            // build the unique character dictionary.
            foreach(char c in S_char)
            {
                if (unique_string_char.ContainsKey(c))
                {
                    // increase the frequency of the existing char.
                    unique_string_char[c] = unique_string_char[c] + 1;
                }
                else
                {
                    // add the unique char to the dictionary
                    unique_string_char.Add(c, 1);
                }
            }

            // iterate over the dictionary to create the unique list , also store their frequency count.
            foreach(KeyValuePair<char , int> keyValuePair in unique_string_char)
            {
                // build the unique_string and the the corresponding frequency of the unique_string
                unique_string.Add(keyValuePair.Key);
                unique_string_frequency.Add(keyValuePair.Value);
            }


            Console.WriteLine("permutations of the given string  are :");

            //FindPermutations_lexically(S_char, 0, permuted_string);
            //call the function to calculate the permutations.

            FindPermutations_lexographical(unique_string, unique_string_frequency, permuted_string, 0 , string_length);

            Console.ReadLine();
        }
    }
}
