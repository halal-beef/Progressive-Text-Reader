using System;
using System.IO;
using System.Net;
using Dottik.PTR;

namespace Dottik.PTR
{
    public class RequestFile
    {
        public static void GetFile(string URI, string targetDirectory, string fileName) {

            File.Delete(Data.executionPath + fileName);
            //Create a WebClient
            WebClient client = new WebClient
            {
                //Make it download a file from repository for updates
                Encoding = System.Text.Encoding.UTF8
            };
            client.DownloadFile(URI, fileName);
            Console.Write(@"Downloaded '{2}' Saving to {0}{1}\{2}...", Data.executionPath, targetDirectory,  fileName);

            // This will copy the downloaded file to a targetDirectory specified when calling this method
            Directory.CreateDirectory(Data.executionPath + targetDirectory);
            if (!File.Exists(Data.executionPath + targetDirectory + @"\" + fileName)) {
                File.Copy(Data.executionPath + fileName, Data.executionPath + targetDirectory + @"\" + fileName);
            } else {
                File.Delete(Data.executionPath + targetDirectory + @"\" + fileName);
                File.Copy(Data.executionPath + fileName, Data.executionPath + targetDirectory + @"\" + fileName);
            }
        }
    }
}