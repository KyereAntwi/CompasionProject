using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels.Models
{
    public class Challenge
    {
        [Key]
        public int ChallengeID { get; set; }

        [Required]
        [StringLength(500)]
        public string ChallengeTitle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<ChildChallenge> Children { get; set; }
    }
}
