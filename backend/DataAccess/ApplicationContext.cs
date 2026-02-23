using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents the <see cref="DbContext"/> for all entities stored in the db.<br></br>
    /// Mapped as TPC (Table Per Class).
    /// </summary>
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseNpgsql("Host=localhost:5432;Database=LifeTracker;Username=postgres;Password=mysecretpassword");

        // Auth
        public DbSet<User> Users => Set<User>();

        // Finance
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<RecurringTransaction> RecurringTransactions => Set<RecurringTransaction>();

        // Tasks
        public DbSet<CalendarTask> CalendarTasks => Set<CalendarTask>();

        // Notes
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<Group> Groups => Set<Group>();

        /// <summary>
        /// Configures the schema for the context.<br></br>
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Finance
            builder.Entity<CalendarTask>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasMany(e => e.Notes).WithMany(e => e.CalendarTasks);
                e.ToTable("CalendarTask");
            });

            // Notes
            builder.Entity<Group>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Parent).WithMany(e => e.Children);
                e.ToTable("Group");
            });

            builder.Entity<Note>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Parent).WithMany(e => e.Notes);
                e.ToTable("Note");
            });
        }


    }
}
