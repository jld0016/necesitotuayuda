using NYHApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.ViewModels.ProposalsViewModels
{
    public class ProposalHelpViewModel
    {
        public Proposal Proposal { get; set; }

        public ICollection<HelpTypeJob> HelpsTypesJobPainting { get; set; }

        public ICollection<HelpTypeJob> HelpsTypesJobMansonry { get; set; }

        public ICollection<HelpTypeJob> HelpsTypesJobPlumbing { get; set; }

        public ICollection<HelpTypeJob> HelpsTypesJobElectricity { get; set; }
    }
}
