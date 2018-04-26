using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("TypesRoads")]
    public class TypeRoad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTypeRoad { get; set; }

        [Required]
        [Display(Name = "Road", ResourceType = typeof(Resources.Account.Resource))]
        public string Name { get; set; }
    }
}
