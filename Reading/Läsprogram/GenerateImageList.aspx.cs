using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Läsprogram
{
    // Reads all files in the image and jippi_image folders, and generates image_list.txt in json format. 
    public partial class GenerateImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get all images from images folder
            string folderPath = Server.MapPath("images");
            string[] filePaths = Directory.GetFiles(folderPath);
            filePaths = removeThumbs(filePaths);


            string json = @"{";

            string filelist = @"""images"":[" +  getImageListAsJson(filePaths) + "]";
            json += filelist + ",";



            folderPath = Server.MapPath("jippi_images");
            filePaths = Directory.GetFiles(folderPath);



            string jippifilelist = @"""jippi_images"":[" + getImageListAsJson(filePaths) + "]";
            json += jippifilelist;

            json += "}";

            System.IO.File.WriteAllText(Server.MapPath("image_list.txt"), json);
        }

        private string[]   removeThumbs(string[] fileList)
        {
            List<string>    returnList = new List<string>();

            for (int i=0; i<fileList.Length; i++)
            {
                if (!fileList[i].Contains("Thumbs.db"))
                {
                    returnList.Add(fileList[i]);
                }
            }

            return returnList.ToArray();
        }

        private string getImageListAsJson(string[] filePaths)
        {
            string json = @"";

            for (int i = 0; i < filePaths.Length; i++)
            {
                string selectedFile = filePaths[i];

                if (!selectedFile.Contains("Thumb")) {

               
                    json += @"""" + getFileName(selectedFile) + @"""";
                    if (i < filePaths.Length - 1)
                    {
                        json += ",";
                    }
                }
                else
                {
                    File.Delete(selectedFile);
                }
            }

            return json;
        }

       
        private string getFileName(string filePath)
        {
            string[] filePathParts = filePath.Split(@"\\".ToCharArray());

            string lastFilePathPart = filePathParts[filePathParts.Length - 1];

            return lastFilePathPart;
        }

    }
}