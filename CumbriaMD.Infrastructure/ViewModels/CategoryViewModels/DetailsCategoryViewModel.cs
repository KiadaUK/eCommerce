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
    public class DetailsCategoryViewModel
    {
        public DetailsCategoryViewModel()
        {
            Subcategories = new List<Category>();
        }

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Parent Category")]
        public string ParentName { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Position")]
        public int OrderInList { get; set; }

        [DisplayName("Subcategories")]
        public IEnumerable<Category> Subcategories { get; set; }

    }
}
