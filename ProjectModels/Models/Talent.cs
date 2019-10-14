using System.Collections.Generic;

namespace ProjectModels.Models
{
    public class Talent
    {
        public int TalentID { get; set; }
        public string TalentTitle { get; set; }
        public string Description { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }
    }
}
