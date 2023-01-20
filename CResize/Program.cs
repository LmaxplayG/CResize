using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CResize
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 0, height = 0;
            foreach (string arg in args)
            {
                if (arg.Equals("/f"))
                {
                    Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                    Console.WriteLine(String.Format("Resized to {0} {1}", Console.WindowWidth, Console.WindowHeight));
                    return;
                }
                if (arg.StartsWith("/w:"))
                    width = int.Parse(arg.Substring(3));
                if (arg.StartsWith("/h:"))
                    height = int.Parse(arg.Substring(3));
            }

            if (width > 0 || height > 0)
                try
                {
                    if (height == 0) height = Console.WindowHeight;
                    if (width == 0) width = Console.WindowWidth;
                    Console.SetWindowSize(width, height);
                }
                catch
                {
                    Console.WriteLine("Something went wrong! (maybe the size was too large?)");
                }
            else
                Console.WriteLine("CResize v1.0.0 - Resize legacy terminal windows\nUsage: CResize.exe /w:WIDTH /h:HEIGHT | CResize /f");
        }
    }
}
