using System;

namespace ProjectModels.Models.SponserActivities
{
    public class Letter
    {
        public int LetterID { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }

        public int SponcerID { get; set; }
        public Sponser Sponser { get; set; }

        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Read { get; set; }
    }
}
