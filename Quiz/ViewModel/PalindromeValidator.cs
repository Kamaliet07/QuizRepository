using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel
{
   public class PalindromeValidator
    {
        /// <summary>
        /// Method to evaluate Palindrome
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns>boolean</returns>
        public static bool PalindromeDeterminer(string inputString)
        {
            // Set min value and max value.
            int min = 0;
            int max = inputString.Length - 1;
            while (true)
            {
                // Return true if min value become greater then max value
                if (min > max)
                {
                    return true;
                }

                // Get character at min value and max value
                char a = inputString[min];
                char b = inputString[max];

                // Validate the character at min value and max value
                if (char.ToLower(a) != char.ToLower(b))
                {
                    // If not found equal, Means string is not palindrome, return false
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
