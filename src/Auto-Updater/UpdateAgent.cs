using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using static Dottik.PTR.Data;


namespace Dottik.PTR
{
    public class UpdateAgent
    {
        public static void CheckUpdate(string dl) {

            string fileName = "newVersion.zip", temporalDir = "temp";
            int latest = latestVersionCode, current = versionCode;
            WebClient client = new WebClient();

            if (current == latest) {
                Console.WriteLine("No Updates Detected");
            } else if (current < latest) {
                Console.WriteLine("New Version Detected!");

                //We Download the latest application zip
                // BROKEN, NEEDS FIX
                client.DownloadFile(dl, fileName);

                //We create a temporal directory to store the zip file and then copy it to there afterwards
                Directory.CreateDirectory(executionPath + temporalDir);
                File.Copy(executionPath + fileName, executionPath + temporalDir + @"\" + fileName);
                ZipFile.ExtractToDirectory(executionPath + temporalDir + @"\" + fileName, executionPath + "New Version");

                File.Delete(executionPath + temporalDir + @"\" + fileName);
                Directory.Delete(executionPath + temporalDir);
                File.Create(executionPath + "UpdatePerformed.dat");

            }
        }
        // WIP
        public static void CheckLocalUpdate()
        {

            if (File.Exists(executionPath + "UpdatePerformed.dat")) {
                programMode = "applyUpdate";
            } else {
            }
        }
    }
}