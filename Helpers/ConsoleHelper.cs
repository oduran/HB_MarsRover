using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Helpers
{
    public static class ConsoleHelper
    {
        // Console Writeline with determined color
        public static void WriteLine(string message,ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }
    }
}
