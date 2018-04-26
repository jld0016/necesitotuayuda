using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Groups")]
    public class ApplicationGroup
    {
        [Key]
        [Required]
        public int IdGroup { get; set; }

        [Display(Name = "NameGroup", ResourceType = typeof(Resources.Account.Resource))]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ApplicationRoleGroup> RolesGroups { get; set; }

        public virtual ICollection<ApplicationUser> Users { get;set; }

    }
}
