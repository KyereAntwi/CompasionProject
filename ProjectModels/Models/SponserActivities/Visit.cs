using System;

namespace ProjectModels.Models.SponserActivities
{
    public class Visit
    {
        public int VisitID { get; set; }

        public int SponserID { get; set; }
        public Sponser Sponser { get; set; }

        public DateTime VisitDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public bool Visited { get; set; }
    }
}
