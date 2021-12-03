using System;
using System.IO;
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
            string text = File.ReadAllText(Data.executionPath + fileFolder + @"\" + jsonFileName), b = "";
            JSONValues jsonValues = JsonSerializer.Deserialize<JSONValues>(text);

            b = jsonValues.VersionCode.ToString();
            if(int.TryParse(b, out int t)) {
                Data.latestVersionCode = t;
                Data.latestVersion = jsonValues.Version;
                Data.downloadLink = jsonValues.DownloadLink;
                Console.WriteLine("Current version is {0}, Latest is {1}", Data.versionCode, Data.latestVersionCode);
            } else {
                Exception JSON_parse_error = new Exception("Error Parsing JSON File. Report to Developer!");
                throw JSON_parse_error;
            }
        }
    }
}