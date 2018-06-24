using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("EnterprisesTypesJob")]
    public class EnterpriseTypeJob
    {
        public long IdEnterprise { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        public long IdTypeJob { get; set; }

        public virtual TypeJob TypeJob { get; set; }

        public int Rating { get; set; }
    }
}
