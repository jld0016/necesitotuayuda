using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Enterprises")]
    public class Enterprise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEnterprise { get; set; }

        [Required]
        [Display(Name = "CodeEnterprise", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string CodeEnterprise { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Name { get; set; }

        [Display(Name = "FiscalName", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string FiscalName { get; set; }

        [Required]
        [Display(Name = "CIF", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string CIF { get; set; }

        [Display(Name = "Road", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int IdTypeRoad { get; set; }

        public virtual TypeRoad TypeRoad { get; set; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Address { get; set; }

        [Display(Name = "Number", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Number { get; set; }

        [Display(Name = "Floor", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Floor { get; set; }

        [Display(Name = "Door", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Door { get; set; }

        [Display(Name = "UnstructuredAddress", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string UnstructuredAddress { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string PostalCode { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string City { get; set; }

        [Display(Name = "Province", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int? IdProvince { get; set; }

        public virtual Province Province { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [Display(Name = "Phone1", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Phone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Phone2 { get; set; }

        public string Latitute { get; set; }

        public string Longitude { get; set; }

        [Display(Name = "IdUserAdministrator", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string IdUserAdministrator { get; set; }

        public ApplicationUser UserAdministrator { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public ApplicationUser UserLastModified { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
