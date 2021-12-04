using System;
using System.IO;
using System.IO.Compression;
using System.Net;


namespace Dottik.PTR
{
    public class UpdateAgent
    {
        public static void CheckUpdate(string dl) {

            string fileName = "newVersion.zip", temporalDir = "temp";
            int latest = Data.latestVersionCode, current = Data.versionCode;
            WebClient client = new WebClient();

            if (current == latest) {
                Console.WriteLine("No Updates Detected");
            } else if (current < latest) {
                Console.WriteLine("New Version Detected!");

                //We Download the latest application zip
                // BROKEN, NEEDS FIX
                client.DownloadFile(dl, fileName);

                //We create a temporal directory to store the zip file and then copy it to there afterwards
                Directory.CreateDirectory(Data.executionPath + temporalDir);
                File.Copy(Data.executionPath + fileName, Data.executionPath + temporalDir + @"\" + fileName);
                ZipFile.ExtractToDirectory(Data.executionPath + temporalDir + @"\" + fileName, Data.executionPath + "New Version");

                File.Delete(Data.executionPath + temporalDir + @"\" + fileName);
                Directory.Delete(Data.executionPath + temporalDir);
                File.Create(Data.executionPath + "UpdatePerformed.dat");

            }
        }
        // WIP
        public static string CheckLocalUpdate()
        {

            if (File.Exists(Data.executionPath + "UpdatePerformed.dat")) {
                Data.programMode = "applyUpdate";
                return "Update Mode Applied";
            } else {
                return "Normal Execution";
            }
    }
    }
}