using System;
using System.Collections.Generic;

namespace ProjectModels.Models.Academics
{
    public class Class
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
