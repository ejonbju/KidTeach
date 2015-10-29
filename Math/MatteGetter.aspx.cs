using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matteprogram
{
    public partial class MatteGetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get all images from images folder
            string folderPath = Server.MapPath("images");

            string[] filePaths = Directory.GetFiles(folderPath);


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

        private string getImageListAsJson(string[] filePaths)
        {
            string json = @"";

            for (int i = 0; i < filePaths.Length; i++)
            {
                string selectedFile = filePaths[i];

                if (!selectedFile.Contains("Thumb"))
                {


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