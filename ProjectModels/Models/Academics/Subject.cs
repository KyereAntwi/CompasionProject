using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models.Academics
{
    public class Subject
    {
        public int SubjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        public virtual ICollection<DepartmentSubject> Departments { get; set; }
    }
}
