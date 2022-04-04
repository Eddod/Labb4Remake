using Labb4RemakeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.DbModels
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> TblPersons { get; set; }
        public DbSet<Interest> TblInterests { get; set; }
        public DbSet<Website> TblWebsites { get; set; }
        public DbSet<PersonInterest> TblPersonInterests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            modelBuilder.Entity<Website>()
                .HasData
                (new Website
                {
                    WebsiteId = 1,
                    Link = "https://www.youtube.com/channel/UCAL3JXZSzSm8AlZyD3nQdBA"
                });
            modelBuilder.Entity<Website>()
                .HasData
                (new Website
                {
                    WebsiteId = 2,
                    Link = "https://sv.wikipedia.org/wiki/Portal:Huvudsida"

                });
            modelBuilder.Entity<Website>()
                .HasData
                (new Website
                {
                    WebsiteId = 3,
                    Link = "https://www.spotify.com/se/"
                });
            modelBuilder.Entity<Interest>()
                .HasData
                (new Interest
                {
                    InterestId = 1,
                    InterestTitle = "Nature"
                });
            modelBuilder.Entity<Interest>()
                .HasData
                (new Interest
                {
                    InterestId = 2,
                    InterestTitle = "Knowledge"


                });
            modelBuilder.Entity<Interest>()
                .HasData
                (new Interest
                {
                    InterestId = 3,
                    InterestTitle = "Music"
                });
            modelBuilder.Entity<Person>()
                .HasData
                (new Person
                {
                    PersonId = 1,
                    FirstName = "Harald",
                    LastName = "Nybord",
                    PersonalNumber = "000912-2131"
                });
            modelBuilder.Entity<Person>()
                .HasData
                (new Person
                {
                    PersonId = 2,
                    FirstName = "Laban",
                    LastName = "Hansson",
                    PersonalNumber = "19941209-2331"
                });
            modelBuilder.Entity<Person>()
                .HasData
                (new Person
                {
                    PersonId = 3,
                    FirstName = "Karl",
                    LastName = "Svahn",
                    PersonalNumber = "19880808-2333"
                });
            modelBuilder.Entity<PersonInterest>()
                .HasData
                (new PersonInterest
                {
                    Id = 1,
                    PersonId = 1,
                    InterestId = 1,
                    WebsiteId = 1

                });
            modelBuilder.Entity<PersonInterest>()
                .HasData
                (new PersonInterest
                {
                    Id = 2,
                    PersonId = 1,
                    InterestId = 2,
                    WebsiteId = 2

                });
            modelBuilder.Entity<PersonInterest>()
                .HasData
                (new PersonInterest
                {
                    Id = 3,
                    PersonId = 3,
                    InterestId = 3,
                    WebsiteId = 3

                });

        }
    }
}
