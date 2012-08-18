using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using CumbriaMD.Infrastructure.ViewModels.CustomValidation;
using CumbriaMD.Infrastructure.ViewModels.DisplayAttributes;


namespace CumbriaMD.Infrastructure.ViewModels.ImageViewModels
{
    public class MultiImageUploader
    {
        [PermittedFileExtension("jpeg, jpg, png, gif")]
        [MaxFileSize("2MB")]
        [Knockout("click: cropImage", "file")]
        [UIHint("MultiImageUploader")]
        public HttpPostedFileBase File { get; set; }

    }
}
