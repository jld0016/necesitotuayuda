using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("TypesJobs")]
    public class TypeJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdTypeJob { get; set; }

        public string Name { get; set; }

        public int IdJob { get; set; }

        public virtual Job Job { get; set; }

        public virtual ICollection<HelpTypeJob> HelpsTypesJobs { get; set; }

        public virtual ICollection<EnterpriseTypeJob> EnterprisesTypesJob { get; set; }
    }
}
