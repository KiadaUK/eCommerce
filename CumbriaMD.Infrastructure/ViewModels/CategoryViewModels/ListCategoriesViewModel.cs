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
    public class ListCategoriesViewModel 
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("PName")]
        public string ParentName { get; set; }

        [DisplayName("PId")]
        public int ParentId { get; set; }

        [DisplayName("Category Name")] 
        [Required]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Position  ")]
        public int OrderInList { get; set; }

        //public Image DefaultImage { get; set; }


        //  public IList<Product> Products { get; protected set; }
    }
}
