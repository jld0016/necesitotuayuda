using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Helps")]
    public class Help
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdHelp { get; set; }

        [Required]
        public string CodeHelp { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Resources.Help.Resource))]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Help.Resource))]
        public string Description { get; set; }

        public string IdUser { get; set; }

        public ApplicationUser UserHelp { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public ApplicationUser UserLastModified { get; set; }
    }
}
