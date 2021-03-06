﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PoolManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       public ICollection<Message> Messages { get; set; }
        [ForeignKey("SessionsId")]
        public virtual IEnumerable<Session> Sessions { get; set; }

        public int? SessionsId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Drill> Drills { get; set; }
        public DbSet<DrillSet> DrillSets { get; set; }
        public DbSet<DrillsInSet> DrillsInSets { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageTopic> MessageTopics { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}