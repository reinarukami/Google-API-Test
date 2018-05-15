using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using Google_API_Test.Services;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using System.Drawing;
using System.IO;
using System.Configuration;
using Google.Apis.Drive.v3.Data;
using Google_API_Test.Models;

namespace Google_API_Test
{
    public partial class Form1 : Form
    {
        internal static DriveService service;
        internal static FileList request;
        internal static List<FileDetails> test = new List<FileDetails>();

        public Form1()
        {

            InitializeComponent();

            //Initialize service
            service = GoogleDriveFilesRepository.GetService();

            //Set Page Token to null
            string pageToken = null;
            ListFiles(service, ref pageToken);

            //List Photos
            foreach (var item in test)
            {
                ListImages.Items.Add(item.FileName);
                DeleteComboBox.Items.Add(item.FileName);
            }
            string path = "D:\\Robin 2.0\\Medias\\Pictures\\Wallpaper\\link.jpg";

            GoogleDriveFilesRepository.UploadImage(path, service);

        }

        private static void ListFiles(DriveService service, ref string pageToken)
        {
            // Define parameters of request.

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.PageToken = pageToken;
            listRequest.Spaces = "drive";
            listRequest.Q = "'10TVA8fya_XoPa0nwg7m2WPsqh_scfyK4' in parents";
            //listRequest.Q = "'root' in parents";

            request = listRequest.Execute();

            if (request.Files != null && request.Files.Count > 0)
            {

                foreach (var file in request.Files)
                {
                    GoogleDriveFilesRepository.DownloadFile(service, file);
              
                    test.Add(new FileDetails() {
                        FileID = file.Id,
                        FileName = file.Name
                    }); 
                }

                pageToken = request.NextPageToken;

            }
            else
            {
                MessageBox.Show("No Files Found");
            }

        }

        private void ListImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            newPicture.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["ImagesPath"], ListImages.Text);
        }

        private void DeleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ntest = test.Find(o => o.FileName == DeleteComboBox.Text);
            service.Files.Delete(ntest.FileID).Execute();   
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
