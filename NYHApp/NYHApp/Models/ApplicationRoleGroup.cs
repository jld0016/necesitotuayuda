using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("RolesGroups")]
    public class ApplicationRoleGroup
    {
        public string IdRole { get; set; }

        public int IdGroup { get; set; }

        public virtual IdentityRole Role { get; set; }

        public virtual ApplicationGroup Group { get; set; }
    }
}
