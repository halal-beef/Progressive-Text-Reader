using System;
using System.IO;
using Dottik.PTR.Update;
using static System.Console;
using static Dottik.PTR.Data;
using static Dottik.PTR.FileRead;

namespace Dottik.PTR
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedString = String.Join(' ',args).Split("--");
            string customText;
            int delay = 50;
            foreach (var argument in splittedString)
            {
                switch(argument)
                {
                    case string a when a.Contains("latency="):
                        string[] msec = argument.Split('=');
                    string wordDelay = msec[1];
                    if(!int.TryParse(wordDelay, out delay)) {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        Write("Invalid Latency value! Try again.");
                        ForegroundColor = ConsoleColor.Gray;
                        Environment.Exit(69);
                        break;
                    case "help":
                        programMode = "help";
                        break;
                    case "custom":
                        programMode = "customText";
                        break;
                    case "create-text-file":
                        WriteLine("Creating text file...");
                        File.CreateText(Data.fileName);
                        WriteLine("Done!");
                        break;
                     case "check-update":
                        programMode = "checkUpdates";
                        break;
                }               
            }

            // STILL IN WIP!
            UpdateAgent.CheckLocalUpdate();

            switch (programMode)
            {
                case "customText":
                    WriteLine("Please, Write the your custom text: ");
                    customText = ReadLine();
                    ReadTextNoArray(customText, delay);
                    break;
                case "help":
                    Help.PrintHelp();
                    break;
                case "checkUpdates":
                    RequestFile.GetFile("https://raw.githubusercontent.com/usrDottik/Progressive-Text-Reader/master/Updater.json", "Do Not Delete", "Update.json");
                    JSONReading.ReadJSON("Do Not Delete", "Update.json");
                    UpdateAgent.CheckUpdate(downloadLink);
                    break;
                case "applyUpdate":

                    break;
                default:
                    Write("///// If you need to access help command use '--help' ///// \n \n");
                    ReadFile(delay);
                    break;
            }
            

        }
    }
}
