using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models.Academics
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<DepartmentSubject> Subjects { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
