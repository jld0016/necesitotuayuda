using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCountry { get; set; }

        [Required]
        [Display(Name = "NameCountry", ResourceType = typeof(Resources.Account.Resource))]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Enterprise> Enterprises { get; set; }
    }
}
