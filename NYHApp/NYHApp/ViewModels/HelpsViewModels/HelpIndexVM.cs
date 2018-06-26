using NYHApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.ViewModels.HelpsViewModels
{
    public class HelpIndexVM
    {
        public FilterHelp Filter { get; set; }

        public ICollection<HelpRating> ListHelp { get; set; } 
    }
}
