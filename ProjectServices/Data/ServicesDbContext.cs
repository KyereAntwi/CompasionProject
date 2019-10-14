using Microsoft.EntityFrameworkCore;
using ProjectModels.Models;
using ProjectModels.Models.Academics;
using ProjectModels.Models.SponserActivities;

namespace ProjectServices.Data
{
    public class ServicesDbContext : DbContext
    {
        public ServicesDbContext(DbContextOptions<ServicesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // initializing models
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChildChallenge> ChildChallenges { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<ChildNeed> ChildNeeds { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sponser> Sponsers { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<AcademicTerm> AcademicTerms { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<TakeCare> TakeCares { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
