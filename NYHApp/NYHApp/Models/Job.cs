using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJob { get; set; }

        public string Name { get; set; }

        public virtual ICollection<HelpJob> HelpsJobs { get; set; }

        public virtual ICollection<EnterpriseJob> EnterprisesJobs { get; set; }

        public virtual ICollection<TypeJob> TypesJob { get; set; }
    }
}
