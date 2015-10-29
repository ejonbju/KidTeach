using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Läsprogram
{
    public partial class ReadingGetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get all images from images folder
            string folderPath = Server.MapPath("images");

            string[] filePaths = Directory.GetFiles(folderPath);

            

            // Select 4 of them
            int numberOfImages = 3;
            List<int> imageIndexes = getImageIndexList(filePaths.Length - 1, numberOfImages);

            string jsonImageList = getImageListAsJson(filePaths, imageIndexes);



            // Select JIPPI image
            folderPath = Server.MapPath("jippi_images");
            filePaths = Directory.GetFiles(folderPath);
            imageIndexes = getImageIndexList(filePaths.Length - 1, 1);
            string jsonJippiImage = @"""jippi_image"":""" + getFileName(filePaths[imageIndexes[0]]) + @"""";


            string json = "{" + jsonJippiImage + "," + jsonImageList + "}";


            Response.Write(json);

        }

        private string getImageListAsJson(string[] filePaths, List<int> imageIndexes)
        {
            string json = @"""images"":[";

            for (int i = 0; i < imageIndexes.Count; i++)
            {
                string selectedFile = filePaths[imageIndexes[i]];

                json += getFileAsJson(selectedFile);
                if (i < imageIndexes.Count - 1)
                {
                    json += ",";
                }
            }

            json += "]";
            return json;
        }

        private string getFileAsJson(string filePath)
        {
            string json = "{";

            string fileName = getFileName(filePath);

            json += @"""word"":""" + getFileNameToWord(fileName) + @""",";

            json = json + @"""image_path"":""images/" + fileName + @"""}";

            return json;
        }

        private string getFileName(string filePath)
        {
            string[] filePathParts = filePath.Split(@"\\".ToCharArray());

            string lastFilePathPart = filePathParts[filePathParts.Length - 1];

            return lastFilePathPart;
        }

        private string getFileNameToWord(string fileName)
        {
            string[] fileNameParts = fileName.Split(".".ToCharArray());

            return fileNameParts[0].ToUpper();

        }

        private List<int> getImageIndexList(int topValue, int numberOfIndexes)
        {
            List<int> imageIndexes = new List<int>();

            Random indexGenerator = new Random();
            while(imageIndexes.Count < numberOfIndexes)
            {
                int indexCandidate = indexGenerator.Next(topValue);

                if ( !doesIndexAlreadyExist(imageIndexes,indexCandidate))
                {
                    imageIndexes.Add(indexCandidate);
                }
            }

            return imageIndexes;

        }

        private bool doesIndexAlreadyExist(List<int> existingIndexes, int indexToTest)
        {
            bool valueAlreadyExists = existingIndexes.Contains(indexToTest);

            return valueAlreadyExists;
        }

    }
}