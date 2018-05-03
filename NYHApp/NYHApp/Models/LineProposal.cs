using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("LinesProposals")]
    public class LineProposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdLineProposal { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Proposal.Resource))]
        public string Description { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Proposal.Resource))]
        public decimal Price { get; set; }

        public long IdProposal { get; set; }

        [Display(Name = "Proposal", ResourceType = typeof(Resources.Proposal.Resource))]
        public virtual Proposal Proposal { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public ApplicationUser UserLastModified { get; set; }
    }
}
