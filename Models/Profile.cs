using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class Profile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public string IdentityUser { get; set; }
        public Profile(string identityUser)
        {
            IdentityUser = identityUser;
        }
    }
}
