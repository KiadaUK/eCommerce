using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CumbriaMD.Infrastructure.ViewModels.CustomValidation;

namespace CumbriaMD.Infrastructure.ViewModels.TestViewModels
{
    public class TestIndexViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
