using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProvince { get; set; }

        [Required]
        [Display(Name = "NameProvince", ResourceType = typeof(Resources.Account.Resource))]
        public string Name { get; set; }

        public virtual ICollection<Enterprise> Enterprises { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
