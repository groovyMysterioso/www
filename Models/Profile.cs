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
        public Page Page { get; set; }
        public int PageID { get; set; }
        public Profile() { }
        public Profile(string identityUser)
        {
            IdentityUser = identityUser;
        }
        public Profile(ProfileVM profileVM)
        {
            Id = profileVM.Id;
            Name = profileVM.Name;
            Description = profileVM.Description;
            ProfileImage = profileVM.ProfileImage;
            IdentityUser = profileVM.IdentityUser;

        }
    }
}
