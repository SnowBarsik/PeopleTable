using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PeopleTable.Identity;
using PeopleTable.Models;

namespace PeopleTable.EntityFramework
{
    public class PeopleDbContext : IdentityDbContext<PeopleUser>
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PeopleDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static PeopleDbContext Create()
        {
            return new PeopleDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Guid)
                .HasMany(p => p.TagList)
                .WithRequired()
                .HasForeignKey(t => t.PersonId);

            modelBuilder.Entity<Tag>().HasRequired(t => t.Person).WithMany().HasForeignKey(p => p.PersonId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
