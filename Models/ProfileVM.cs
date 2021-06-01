using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static www.Controllers.PostsController;

namespace www.Models
{
    public class ProfileVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        internal string IdentityUser { get; set; }
        public ProfileVM(string identityUser)
        {
            IdentityUser = identityUser;
        }
   
    }
}
