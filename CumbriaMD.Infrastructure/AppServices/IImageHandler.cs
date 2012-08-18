using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using eDetectors.Domain;

namespace CumbriaMD.Infrastructure.AppServices
{
    public interface IImageHandler
    {
        Image ResizeImage(Image image, int maxWidth, int maxHeight);

        bool SaveImageToDisk(HttpPostedFileBase image, string fileFolder);

        Image BuildImage(HttpPostedFileBase image, string fileFolder);

        Image EditImage(HttpPostedFileBase image, string fileFolder, Image oldImage);



    }
}
