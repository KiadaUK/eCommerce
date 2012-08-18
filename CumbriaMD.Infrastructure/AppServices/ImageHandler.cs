using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Castle.Core.Logging;
using Image = eDetectors.Domain.Image;

namespace CumbriaMD.Infrastructure.AppServices
{
    public class ImageHandler : IImageHandler
    {
        private readonly ILogger _logger;

        public ImageHandler(ILogger logger)
        {
            _logger = logger;
        }

        public static char DirSeparator = System.IO.Path.DirectorySeparatorChar;
        public static string FilesPath = "Content" + DirSeparator + "images" + DirSeparator;
        public static string currentBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var height = image.Height;
            var width = image.Width;

            if(width >= height && width > maxWidth)
            {
                decimal multiplier = width/maxWidth;
                width = (int)decimal.Round(width/multiplier);
                height = (int)decimal.Round(height/multiplier);
            }

            if(height > width && height > maxHeight)
            {
                decimal multiplier = height/maxHeight;
                width = (int)decimal.Round(width / multiplier);
                height = (int)decimal.Round(height / multiplier);
            }

            image.Width = width;
            image.Height = height;
            return image;
        }

        public bool SaveImageToDisk(HttpPostedFileBase image, string fileFolder)
        {
            if(null == image){ return false; }

            if(!(image.ContentLength > 0)){ return false; }

            var filename = image.FileName;
            var fileExt = Path.GetExtension(image.FileName);

            var path = FilesPath + fileFolder;


            if (null == fileExt) { return false; }

            if (!Directory.Exists(currentBaseDirectory + path))
            {
                Directory.CreateDirectory(currentBaseDirectory + path);
            }
            image.SaveAs(currentBaseDirectory + path + DirSeparator + filename);

            return true;
        }

        public Image BuildImage(HttpPostedFileBase image, string fileFolder)
        {

            var newImage = new Image();
            var convertedImage = System.Drawing.Image.FromStream(image.InputStream, true, true);
            SetImageDimensions(newImage, convertedImage);
            newImage.FileSize = image.ContentLength;
            newImage.FileName = image.FileName;
            newImage.FileType = image.ContentType;
            newImage.Uri = "~/Content/images/" + fileFolder + "/";

            return newImage;
        }

        public Image EditImage(HttpPostedFileBase image, string fileFolder, Image oldImage)
        {
            try
            {
                DeleteImage(oldImage);              
            }
            catch(IOException e)
            {
               if(e.Source != null)
               {
                   _logger.WarnFormat("File {2} could not be deleted.");
               }
            }

            return BuildImage(image, fileFolder);   
            
        }

        private Image SetImageDimensions(Image image, System.Drawing.Image convertedImage)
        {
            image.Height = convertedImage.Height;
            image.Width = convertedImage.Width;
            return image;
        }

        private bool DeleteImage(Image image)
        {
            if (image.FileName.Length == 0) { return false; }

            string path = image.Uri + image.FileName;

            if (File.Exists(Path.GetFullPath(currentBaseDirectory + path)))
            {
                File.Delete(Path.GetFullPath(currentBaseDirectory + path));
            }

            return true;
        }





    }
}
