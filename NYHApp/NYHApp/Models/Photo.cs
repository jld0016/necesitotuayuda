using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPhoto { get; set; }

        [Required]
        [Display(Name = "FileName", ResourceType = typeof(Resources.Photo.Resource))]
        public string FileName { get; set; }

        [Required]
        public string Path { get; set; }

        public long IdHelp { get; set; }

        public virtual Help Help { get; set; }

        [Display(Name = "DateUpload", ResourceType = typeof(Resources.Photo.Resource))]
        public DateTime DateUpload { get; set; }

        public DateTime DateLastModified { get; set; }

        public string IdUserLastModified { get; set; }

        public virtual ApplicationUser UserLastModified { get; set; }
    }
}
