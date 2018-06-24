using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Debe introducir un Email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe introducir un Usuario")]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Account.Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe introducir una Contraseña")]
        [StringLength(100, ErrorMessage = "La conttraseña debe de tener un minimo de {1} y máximo de {0} carácteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Account.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas deben de ser iguales")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Account.Resource))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Debe introducir un Nombre")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Account.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe introduce un Apellido")]
        [Display(Name = "Surname1", ResourceType = typeof(Resources.Account.Resource))]
        public string Surname1 { get; set; }

        [Display(Name = "Surname2", ResourceType = typeof(Resources.Account.Resource))]
        public string Surname2 { get; set; }

        [Required(ErrorMessage = "Debe introducir un NIF")]
        [Display(Name = "NIF", ResourceType = typeof(Resources.Account.Resource))]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Debe introducir un Tipo de Vía")]
        [Display(Name = "Road", ResourceType = typeof(Resources.Account.Resource))]
        public int IdTypeRoad { get; set; }

        public virtual TypeRoad TypeRoad { get; set; }

        [Required(ErrorMessage = "Debe introducir una Dirección")]
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

        [Required(ErrorMessage = "Debe introducir un Codigo Postal")]
        [Display(Name = "PostalCode", ResourceType = typeof(Resources.Account.Resource))]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Debe introducir una Ciudad")]
        [Display(Name = "City", ResourceType = typeof(Resources.Account.Resource))]
        public string City { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Account.Resource))]
        public string State { get; set; }

        [Required(ErrorMessage = "Debe introducir un Pais")]
        [Display(Name = "Country", ResourceType = typeof(Resources.Account.Resource))]
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "Debe introducir un Teléfono")]
        [Display(Name = "Phone1", ResourceType = typeof(Resources.Account.Resource))]
        public string Phone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Account.Resource))]
        public string Phone2 { get; set; }
    }
}
