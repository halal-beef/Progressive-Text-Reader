using System;
using System.Threading;
using static System.Console;
using static System.IO.File;
using static Dottik.PTR.Data;

namespace Dottik.PTR
{
    public class FileRead
    {
        private static char[] chars;
        private static int i = 0;
        
        //Read 'mode', prompts us if we read character by character or word by word
        static public void ReadFile(int latency) {

            string[] lines = {""};
            WriteLine("DEBUG: Execution Path of this Program is {0}", executionPath);
            WriteLine("DEBUG: File To Read Path is {0}", executionPath + fileName + "\n");

            WriteLine("Reading Text...");
            
            try {
                lines = ReadAllLines(executionPath + fileName);
            } catch {
                ForegroundColor = ConsoleColor.Red;
                WriteLine ("\n\n--There was no file to read from! \n Terminating Program! \n Please, execute the program with the argument `--create-text-file` or create a file with the name {0}", fileName);
                ForegroundColor = ConsoleColor.Gray;
                Environment.Exit(0);
            }

            WriteLine("Done! \nPrinting... \n////////\n////////\n////////\n");

            ReadText(lines, latency);

            Write("\n////////\n////////\n////////\n Written {0} characters!", i);
        }
        static protected void ReadText(string[] lines, int latency) {

            //Iterate through the lines of text, translate into a char array the current line, print it, sum the chars, leave a space with a \n and then go to next and repeat
            foreach (var letter in lines)
            {
                chars = letter.ToCharArray();
                foreach (var item in chars)
                {
                    Write(item);
                    //I'm too stupid to find another convincing solution more than stopping a whole thread?
                    // YES.
                    Thread.Sleep(latency);
                    i++;
                }
                Write("\n");
            }
        }
        static public void ReadTextNoArray(string line, int latency) {

            // Make our String a char array!
            chars = line.ToCharArray();

            //Print each character with a latency and iterate sum an iteration to indicate the number of written characters!
            foreach (var item in chars) {
                Write(item);
                Thread.Sleep(latency);
                i++;
            }
            Write("\n\n////////\n////////\n////////\n Written {0} characters!", i);
        }
}
}