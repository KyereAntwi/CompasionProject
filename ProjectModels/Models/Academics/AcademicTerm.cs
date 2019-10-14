using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models.Academics
{
    public class AcademicTerm
    {
        [Key]
        public int AcademicTermID { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 5)]
        public string Term { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string Year { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnded { get; set; }
    }
}
