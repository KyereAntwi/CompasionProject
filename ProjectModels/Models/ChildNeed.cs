using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models
{
    public class ChildNeed
    {
        [Key]
        public int ChildNeedID { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
