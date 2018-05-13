using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NYHApp.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Account.Resource))]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname1", ResourceType = typeof(Resources.Account.Resource))]
        public string Surname1 { get; set; }

        [Display(Name = "Surname2", ResourceType = typeof(Resources.Account.Resource))]
        public string Surname2 { get; set; }

        [Required]
        [Display(Name = "NIF", ResourceType = typeof(Resources.Account.Resource))]
        public string NIF { get; set; }

        [Display(Name = "Road", ResourceType = typeof(Resources.Account.Resource))]
        public int IdTypeRoad { get; set; }

        public virtual TypeRoad TypeRoad { get; set; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Resources.Account.Resource))]
        public string Address { get; set; }

        [Display(Name = "Number", ResourceType = typeof(Resources.Account.Resource))]
        public string Number { get; set; }

        [Display(Name = "Floor", ResourceType = typeof(Resources.Account.Resource))]
        public string Floor { get; set; }

        [Display(Name = "Door", ResourceType = typeof(Resources.Account.Resource))]
        public string Door { get; set; }

        [Display(Name = "UnstructuredAddress", ResourceType = typeof(Resources.Account.Resource))]
        public string UnstructuredAddress { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(Resources.Account.Resource))]
        public string PostalCode { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Account.Resource))]
        public string City { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Account.Resource))]
        public string State { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Account.Resource))]
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [Display(Name = "Phone1", ResourceType = typeof(Resources.Account.Resource))]
        public string Phone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Account.Resource))]
        public string Phone2 { get; set; }

        [Display(Name = "Enterprise", ResourceType = typeof(Resources.Account.Resource))]
        public long? IdEnterprise { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        public DateTime DateLastModified { get; set; }

        public virtual ICollection<Help> Helps { get; set; }
    }
}
