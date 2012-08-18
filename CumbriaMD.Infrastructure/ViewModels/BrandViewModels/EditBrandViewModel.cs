using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CumbriaMD.Infrastructure.ViewModels.DisplayAttributes;
using CumbriaMD.Infrastructure.ViewModels.ImageViewModels;
using eDetectors.Domain;

namespace CumbriaMD.Infrastructure.ViewModels.BrandViewModels
{
    public class EditBrandViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get;  set; }

        [MaxLength(50, ErrorMessage = "Must be no longer than 50 characters.")]
        [DisplayName("Brand Name")]
        [Required]
        public string Name { get; set; }
        
        [DisplayName("Show brand on website: ")]
        public bool IsActive { get; set; }

        [Knockout("checked: editImage", "checkbox")]
        [DisplayName("Replace Image: ")]
        public bool  EditImage { get; set; }

        [DisplayName("New Image: ")]
        public MultiImageUploader File { get; set; }

        public Image Image { get; set; }
    }
}
