namespace ProjectModels.Models.SponserActivities
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }

        public int SponserID { get; set; }
        public Sponser Sponser { get; set; }

        public string VolunteeringType { get; set; }
    }
}
