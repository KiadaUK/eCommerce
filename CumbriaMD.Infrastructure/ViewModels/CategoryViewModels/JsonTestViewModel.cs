using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CumbriaMD.Infrastructure.ViewModels.CategoryViewModels
{
    public class JsonTestViewModel
    {

        [DisplayName("Parent Category")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ParentCategoryId { get; set; }

        [DisplayName("Order In Subcategory")]
        public IEnumerable<SelectListItem> CategoryOrderListItems { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int OrderInList { get; set; }

        public JsonTestViewModel()
        {
            this.Categories = new List<SelectListItem>();
            this.CategoryOrderListItems = new List<SelectListItem>();
        }
    }
}
