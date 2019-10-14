using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string PostalAddress { get; set; }
        public string WebUrl { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
