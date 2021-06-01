using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Sender{ get; set; }
        public string[] Recipient { get; set; }
        public bool isDeleted { get; set; }
        public string Attachments { get; set; }
        public Post ()
        {
            Created = DateTime.Now;
            isDeleted = false;
        }

    }

}
