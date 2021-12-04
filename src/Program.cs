using System;
using System.Diagnostics;
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
            string wordDelay = "50", customText = "";
            int delay = 50;

            foreach (var argument in args)
            {
                if (argument.Contains("--latency")) {

                    string[] msec = argument.Split('=');
                    wordDelay = msec[1];
                    if(!int.TryParse(wordDelay, out delay)) {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        Write("Invalid Latency value! Try again.");
                        ForegroundColor = ConsoleColor.Gray;
                        Environment.Exit(69);
                    }

                } else if (argument.Contains("--help")) {
                    programMode = "help";
                } else if (argument.Contains("--custom")) {
                    programMode = "customText";
                } else if (argument.Contains("--create-text-file")) {
                    WriteLine("Creating text file...");
                    File.CreateText(Data.fileName);
                    WriteLine("Done!");
                } else if (argument.Contains("--check-update")) {
                    programMode = "checkUpdates";
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
                    UpdateAgent.CheckUpdate(Data.downloadLink);
                    break;
                case "applyUpdate":
                    //Process updater = new Process();
                    //updater.StartInfo.FileName = "updater.exe";

                    break;
                default:
                    Write("///// If you need to access help command use '--help' ///// \n \n");
                    ReadFile(delay);
                    break;
            }
            

        }
    }
}
