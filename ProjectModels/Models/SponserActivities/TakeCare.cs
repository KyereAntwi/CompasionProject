using System;

namespace ProjectModels.Models.SponserActivities
{
    public class TakeCare
    {
        public int TakeCareID { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }

        public int SponserID { get; set; }

        public DateTime DateStarted { get; set; }
        public bool PolicySigned { get; set; }
    }
}
