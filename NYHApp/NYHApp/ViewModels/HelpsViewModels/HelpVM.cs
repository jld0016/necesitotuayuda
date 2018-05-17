using Microsoft.AspNetCore.Http;
using NYHApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.ViewModels
{
    public class HelpVM
    {
        public Help Help { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
