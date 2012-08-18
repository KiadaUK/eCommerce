using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CumbriaMD.Infrastructure.ViewModels.CustomValidation
{
   // [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _maxFileSize;
        private const string RemoveMbFromFileSizeRegEx = @"[a-zA-z]";  

        // Example: [_maxFileSize("2MB")]
        public MaxFileSizeAttribute(string maxFileSize)
            : base("Uploaded file is too large. Maximum file size is: " + maxFileSize)
        {
            ErrorMessage = "Uploaded file is too large. Maximum file size is: " + maxFileSize;
            string result = Regex.Replace(maxFileSize, RemoveMbFromFileSizeRegEx, "", RegexOptions.IgnoreCase);
            var resultToInt = Int32.Parse(result);

            this._maxFileSize = (resultToInt*1024*1024);

        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(_maxFileSize.ToString()),
                ValidationType = "filesize"
            };
            rule.ValidationParameters["maxsize"] = _maxFileSize;
            yield return rule;
        }


    public override bool IsValid(object value)
    {
        var file = value as HttpPostedFileBase;
        if (file == null)
        {
            return false;
        }
        return file.ContentLength <= _maxFileSize;
    }

    }
}

