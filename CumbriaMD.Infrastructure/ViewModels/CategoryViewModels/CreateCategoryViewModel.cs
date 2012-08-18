using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CumbriaMD.Domain;

namespace CumbriaMD.Infrastructure.ViewModels.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Must be no longer than 50 characters.")]
        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Show category on website?")]
        public bool IsActive { get; set; }

        //public Image DefaultImage { get; set; }

        [DisplayName("Parent Category")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ParentCategoryId { get; set; }

        [DisplayName("Order In Subcategory")]
        public IEnumerable<SelectListItem> CategoryOrderListItems { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int OrderInList { get; set; }

        public CreateCategoryViewModel()
        {
            this.Categories = new List<SelectListItem>();
        }


    }
}
