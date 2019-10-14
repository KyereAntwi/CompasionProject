using ProjectModels.Models.SponserActivities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models
{
    public class Sponser : Person
    {
        [Required]
        [StringLength(500)]
        public string EducationalLevel { get; set; }

        [Required]
        [StringLength(500)]
        public string Occupation { get; set; }

        [Required]
        [StringLength(8)]
        public string MaritalStatus { get; set; }

        [Required]
        [StringLength(500)]
        public string PreferedCommunication { get; set; }

        public virtual ICollection<Volunteer> VolunteeringActivities { get; set; }
        public virtual ICollection<Letter> Letters { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
