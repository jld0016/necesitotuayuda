using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Helps")]
    public class Help
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdHelp { get; set; }

        [Required]
        public string CodeHelp { get; set; }

        [Required(ErrorMessage = "Debe introducir un Título")]
        [Display(Name = "Title", ResourceType = typeof(Resources.Help.Resource))]
        public string Title { get; set; }

        [Required(ErrorMessage = "Debe introducir una Descripción")]
        [Display(Name = "Description", ResourceType = typeof(Resources.Help.Resource))]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Help.Resource))]
        [Required]
        public string IdUser { get; set; }

        public virtual ApplicationUser UserHelp { get; set; }

        [Display(Name = "IsMansonry", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsMansonry { get; set; }

        [Display(Name = "IsPainting", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsPainting { get; set; }

        [Display(Name = "IsPlumbing", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsPlumbing { get; set; }

        [Display(Name = "IsElectricity", ResourceType = typeof(Resources.Help.Resource))]
        public bool IsElectricity { get; set; }

        [Display(Name = "Road", ResourceType = typeof(Resources.Enterprise.Resource))]
        [Required(ErrorMessage = "Debe introducir un Tipo de Vía")]
        public int IdTypeRoad { get; set; }

        public virtual TypeRoad TypeRoad { get; set; }

        [Required(ErrorMessage = "Debe introducir una Dirección")]
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

        [Required(ErrorMessage = "Debe introducir un Código Postal")]
        [Display(Name = "PostalCode", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Debe introducir una Ciudad")]
        [Display(Name = "City", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string City { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string State { get; set; }

        [Required(ErrorMessage = "Debe introducir un Pais")]
        [Display(Name = "Country", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "Debe introducir un Teléfono")]
        [Display(Name = "Phone1", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Phone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string Phone2 { get; set; }

        public string Latitute { get; set; }

        public string Longitude { get; set; }

        [Display(Name = "Close", ResourceType = typeof(Resources.Help.Resource))]
        public bool Close { get; set; }

        [Display(Name = "CloseDate", ResourceType = typeof(Resources.Help.Resource))]
        public DateTime? CloseDate { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public virtual ApplicationUser UserLastModified { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Proposal> Proposals { get; set; }

        public virtual ICollection<HelpJob> HelpsJobs { get; set; }

        public virtual ICollection<HelpTypeJob> HelpsTypesJobs { get; set; }
    }
}
