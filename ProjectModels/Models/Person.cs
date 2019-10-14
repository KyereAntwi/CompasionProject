using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 2)]
        public string MiddleNames { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Nationality { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
