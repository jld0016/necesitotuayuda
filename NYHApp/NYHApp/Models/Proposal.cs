using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Proposals")]
    public class Proposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProposal { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Proposal.Resource))]
        [Required(ErrorMessage = "Introduce una Descripción")]
        public string Description { get; set; }

        [Display(Name = "Total", ResourceType = typeof(Resources.Proposal.Resource))]
        [Required(ErrorMessage = "Introduce un Total")]
        public decimal Total { get; set; }

        [Display(Name = "Help", ResourceType = typeof(Resources.Proposal.Resource))]
        public long IdHelp { get; set; }

        public virtual Help Help { get; set; }

        [Display(Name = "Enterprise", ResourceType = typeof(Resources.Proposal.Resource))]
        public long IdEnterprise { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public ApplicationUser UserLastModified { get; set; }

        public virtual ICollection<LineProposal> LinesProposals { get; set; }
    }
}
