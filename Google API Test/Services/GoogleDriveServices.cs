using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_API_Test.Services
{
    public class GoogleDriveFilesRepository
    {
        //defined scope.
        public static string[] Scopes = { DriveService.Scope.Drive };
        public static string ApplicationName = "AFP Client";

        /// <summary>
        /// Gets the credentials and then returns the service to use the google api
        /// </summary>
        /// <returns></returns>
        public static DriveService GetService()
        {
            UserCredential credential;

            string path = "C:\\Users\\rsumalde\\Documents\\Visual Studio 2015\\Projects\\Google API Test\\Google API Test\\client_id.json";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
            }

           var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = GoogleDriveFilesRepository.ApplicationName,
            });

            return service;
        }
        
        /// <summary>
        /// Download Files
        /// </summary>
        /// <param name="service"></param>
        /// <param name="file"></param>
        /// <param name="saveTo"></param>
        public static void DownloadFile(Google.Apis.Drive.v3.DriveService service, Google.Apis.Drive.v3.Data.File file)
        {

            var request = service.Files.Get(file.Id);
            var stream = new System.IO.MemoryStream();

            string FolderPath = "C:\\Users\\rsumalde\\Documents\\visual studio 2015\\Projects\\Google API Test\\Google API Test\\Images";
            string FilePath = System.IO.Path.Combine(FolderPath, file.Name);

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {                           
                            SaveStream(stream, FilePath);
                            Console.WriteLine("Download complete.");
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream);

        }

        public static void UploadImage(string path, DriveService service)
        {
            var fileMetaData = new Google.Apis.Drive.v3.Data.File();
            fileMetaData.Parents = new List<string>()
            {
                "10TVA8fya_XoPa0nwg7m2WPsqh_scfyK4"
            };

            fileMetaData.Name = "upload.jpg";
            fileMetaData.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMetaData, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
        }



        private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }

     

    }
}
