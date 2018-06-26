using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.ViewModels.HelpsViewModels
{
    public class FilterHelp
    {
        [Display(Name = "Title", ResourceType = typeof(Resources.Help.Resource))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Help.Resource))]
        public string Description { get; set; }

        [Display(Name = "IsMansonry", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsMansonry { get; set; }

        [Display(Name = "IsPainting", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsPainting { get; set; }

        [Display(Name = "IsPlumbing", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsPlumbing { get; set; }

        [Display(Name = "IsElectricity", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsElectricity { get; set; }

        [Display(Name = "Photos", ResourceType = typeof(Resources.Help.Resource))]
        public bool Photos { get; set; }
    }
}
