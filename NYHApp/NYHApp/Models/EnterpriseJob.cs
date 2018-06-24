using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("EnterprisesJobs")]
    public class EnterpriseJob
    {
        public long IdEnterprise { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        public int IdJob { get; set; }

        public virtual Job Job { get; set; }
    }
}
