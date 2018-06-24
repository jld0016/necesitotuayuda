﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models.AccountViewModels
{
    public class ModifyAccountViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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

        public bool IsEnterprise { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseName { get; set; }

        [Display(Name = "FiscalName", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseFiscalName { get; set; }


        [Display(Name = "CIF", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseCIF { get; set; }

        [Display(Name = "Road", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int? EnterpriseIdTypeRoad { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseAddress { get; set; }

        [Display(Name = "Number", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseNumber { get; set; }

        [Display(Name = "Floor", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseFloor { get; set; }

        [Display(Name = "Door", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseDoor { get; set; }

        [Display(Name = "UnstructuredAddress", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseUnstructuredAddress { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterprisePostalCode { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseCity { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseState { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Enterprise.Resource))]
        public int EnterpriseIdCountry { get; set; }

        [Display(Name = "Phone1", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterprisePhone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterprisePhone2 { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resources.Enterprise.Resource))]
        public string EnterpriseEmail { get; set; }

        [Display(Name = "IsMansonry", ResourceType = typeof(Resources.Help.Resource))]
        public bool EnterpriseIsMansonry { get; set; }

        [Display(Name = "IsPainting", ResourceType = typeof(Resources.Help.Resource))]
        public bool EnterpriseIsPainting { get; set; }

        [Display(Name = "IsPlumbing", ResourceType = typeof(Resources.Help.Resource))]
        public bool EnterpriseIsPlumbing { get; set; }

        [Display(Name = "IsElectricity", ResourceType = typeof(Resources.Help.Resource))]
        public bool EnterpriseIsElectricity { get; set; }

        public ICollection<EnterpriseTypeJob> EnterprisesTypesJobPainting { get; set; }

        public ICollection<EnterpriseTypeJob> EnterprisesTypesJobMansonry { get; set; }

        public ICollection<EnterpriseTypeJob> EnterprisesTypesJobPlumbing { get; set; }

        public ICollection<EnterpriseTypeJob> EnterprisesTypesJobElectricity { get; set; }
    }
}
