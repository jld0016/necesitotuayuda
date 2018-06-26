using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int RatingEnterprise { get; set; }

        public int RatingHelp { get; set; }

        public long TotalRating { get; set; }
    }
}
