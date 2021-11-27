using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB_MarsRover.Extensions
{
    public static class CharExtension
    {
        // Upper character
        public static char ToUpper(this char ch)
        {
            return ch.ToUpper();
        }

        // Check input characters are includes or not in constant array 
        public static bool HasIncludeCharArray(this string[] inputChars, string[] arr)
        {
            
            for (int i = 0; i < inputChars.Length; i++)
            {
                if (!arr.Contains(inputChars[i].ToUpperEng()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
