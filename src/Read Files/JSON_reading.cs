using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Dottik.PTR.Update
{
    public class JSONValues
    {
        public string version { get; set; }
        public string downloadLink { get; set; }
    }
    public class JSONReading
    {
        public static void ReadJSON(string fileFolder, string jsonFileName)
        {
            string text = File.ReadAllText(Data.executionPath + fileFolder + @"\" + jsonFileName);

            //
            JSONValues jsonValues = JsonSerializer.Deserialize<JSONValues>(text);

            Data.latestVersion = jsonValues.version;
            Data.downloadLink = jsonValues.downloadLink;

            Console.Write("{0}, {1}", jsonValues.version, jsonValues.downloadLink);
        }
    }
}