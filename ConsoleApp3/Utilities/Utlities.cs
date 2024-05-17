using System;

namespace SQLLabb1.Utilities
{
     public static class Utilities
    {
        //This is a little something I like to do to smooth ReadLine out. 
        //It removes the latest row so I dont have to use Clear method.
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
