using ProjectModels.Models.Academics;
using ProjectModels.Models.SponserActivities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models
{
    public class Child : Person
    {
        [Required]
        public DateTime DateAdmitted { get; set; }

        public int ClassID { get; set; }
        public Class Class { get; set; }

        public virtual ICollection<TakeCare> Sponsers { get; set; }
        public virtual ICollection<ChildNeed> Needs { get; set; }
        public virtual ICollection<Talent> Talents { get; set; }
        public virtual ICollection<ChildChallenge> Challenges { get; set; }
        public virtual ICollection<Transcript> Transcripts { get; set; }
        public virtual ICollection<Letter> Letters { get; set; }
    }
}
