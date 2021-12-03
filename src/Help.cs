using System;
using static System.Console;

namespace Dottik.PTR
{
    public class Help
    {
        public static void PrintHelp() {

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("//////// Progressive Text Reader! ///////");
            WriteLine("//////// Made by {1} ////////", ForegroundColor = ConsoleColor.Green, Data.author);
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("/////////////////////////////////////");
            WriteLine("////////");
            Write("////////"); 
            ForegroundColor = ConsoleColor.Green; 
            Write("   --custom                     |  Allows you to input text directly without the need of a file! \n");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("////////");
            Write("////////");
            ForegroundColor = ConsoleColor.Green;
            Write("   --create-text-file           |  The program will generate a text file from it will read the text from (TL;DR, Input your text in it!) \n");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("////////");
            Write("////////");
            ForegroundColor = ConsoleColor.Green;
            Write("   --latency=<LATENCY-IN-MSEC>  |  Allows you to specify the latency between the characters. Default time is 50msec (Replace <LATENCY-IN-MSEC> with your latency in mili-seconds! 1 Second = 1000Msec) \n");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("////////");
            Write("////////");
            ForegroundColor = ConsoleColor.Green;
            Write("   --check-update               |  Checks for updates of this program and downloads them into a folder named 'New Version'\n");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("////////");
            Write("////////");
            ForegroundColor = ConsoleColor.Green;
            Write("   --help                       |  Display this message\n");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("////////");
            Write("/////////////////////////////////////");
            ForegroundColor = ConsoleColor.Gray;
        }
    }
}