using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.ViewModels.CustomValidation;
using CumbriaMD.Infrastructure.ViewModels.DisplayAttributes;
using CumbriaMD.Infrastructure.ViewModels.ImageViewModels;
using NHibernate;
using eDetectors.Domain;

namespace CumbriaMD.Infrastructure.ViewModels.BrandViewModels
{
    public class CreateBrandViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Must be no longer than 50 characters.")]
        [DisplayName("Name:")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Show brand on website?")]
        public bool IsActive { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Image Image { get; set; }

        [DisplayName("Logo:")]
        [Knockout("click: cropImage", "file")]
        public MultiImageUploader File { get; set; }


    }


}
