using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CumbriaMD.Infrastructure.ViewModels.CustomValidation
{
    public class PermittedFileExtensionAttribute : ValidationAttribute, IClientValidatable
    {
        private IList<string> ValidFileExtensions { get; set; }
        private string SingleStringFileExtensions { get; set; }
       // private const string MimeRegex = "^.*?/"; //Replace everything up to the "/" with "".
        private const string MimeRegex = "^.*?\\."; //Replace everything up to the "/" with "".
        //[PermittedExtensions("jpg, jpeg, png, gif, tif, tiff")]
         public PermittedFileExtensionAttribute(string fileExtensions)
            : base("Selected file is not a permitted image file.")
         {
             this.ValidFileExtensions = new List<string>();
             this.SingleStringFileExtensions = fileExtensions;
             var splitResult = fileExtensions.Split(new Char[] {' ', ',', '.'});

             ErrorMessage = "Selected file is not a permitted image file. Permitted:";
             foreach (var s in splitResult)
             {
                 if (s.Trim() != "")
                 {
                     ValidFileExtensions.Add(s);
                     ErrorMessage += " ." + s;
                 }
             }
         }

         public override string FormatErrorMessage(string name)
         {
             return base.FormatErrorMessage(ValidFileExtensions.ToString()); // This is wrong?
         }

         public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
         {
             var rule = new ModelClientValidationRule
                            {
                                ErrorMessage = FormatErrorMessage("Selected file is not a permitted image file. Permitted:" + SingleStringFileExtensions),
                                ValidationType = "mimetype"
                            };

             rule.ValidationParameters["filetype"] = SingleStringFileExtensions;
                 yield return rule;
             }
                         
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if(file == null)
            {
                return false;
            }
           
        //  var formattedMimeString = Regex.Replace(file.ContentType, MimeRegex, "", RegexOptions.IgnoreCase);
            var formattedMimeString = Regex.Replace(file.FileName, MimeRegex, "", RegexOptions.IgnoreCase);
            foreach(var item in ValidFileExtensions)
            {
                if(formattedMimeString == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}