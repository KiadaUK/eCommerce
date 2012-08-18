﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CumbriaMD.Domain;

namespace CumbriaMD.Infrastructure.ViewModels.BrandViewModels
{
    public class ListBrandsViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; 
 set; }

        [DisplayName("Brand Name")]
        public string Name { get; set; }

        [DisplayName("Activate Brand?")]
        public bool IsActive { get; set; }

    }
}
