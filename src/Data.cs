using System;

namespace Dottik.PTR
{
    public class Data
    {
        public static int latestVersionCode = versionCode;
        public static string latestVersion = "";
        public static string downloadLink = "https://github.com/usrDottik/Progressive-Text-Reader/releases/download/Release/Progressive-Text-Reader.zip";
        public static string programMode = "defaultExecution";
        public static readonly int versionCode = 1;
        public static readonly string applicationVersion = "1.0";
        public static readonly string executionPath = Environment.CurrentDirectory + @"\";
        public static readonly string fileName = "read-this.txt";
        public static readonly string author = "Dottik";
    }
}