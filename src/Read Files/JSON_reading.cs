using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Dottik.PTR.Update
{
    public class JSONValues
    {
        public int VersionCode { get; set; }
        public string Version { get; set; }
        public string DownloadLink { get; set; }
    }
    public class JSONReading
    {
        public static void ReadJSON(string fileFolder, string jsonFileName)
        {
            string text = File.ReadAllText(Data.executionPath + fileFolder + @"\" + jsonFileName);

            //
            JSONValues jsonValues = JsonSerializer.Deserialize<JSONValues>(text);

            Data.latestVersionCode = jsonValues.VersionCode;
            Data.latestVersion = jsonValues.Version;
            Data.downloadLink = jsonValues.DownloadLink;
        }
    }
}