using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using www.Models;

namespace www.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public DbSet<Feed> Feed { get; set; }
        public DbSet<FeedVM> FeedVM { get; set; }
        public DbSet<AppFile> AppFile { get; set; }

    }
}
