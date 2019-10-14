using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels.Models
{
    public class ChildChallenge
    {
        public int ChildChallengeID { get; set; }

        public int ChildID { get; set; }
        public Child Child { get; set; }

        public int ChallengeID { get; set; }
        public Challenge Challenge { get; set; }
    }
}
