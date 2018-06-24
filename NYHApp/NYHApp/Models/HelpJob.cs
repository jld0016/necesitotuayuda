using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("HelpsJobs")]
    public class HelpJob
    {
        public long IdHelp { get; set; }

        public virtual Help Help { get; set; }

        public int IdJob { get; set; }

        public virtual Job Job { get; set; }
    }
}
