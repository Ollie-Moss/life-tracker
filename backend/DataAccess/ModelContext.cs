using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents the <see cref="DbContext"/> for all entities stored in the db.<br></br>
    /// Mapped as TPC (Table Per Class).
    /// </summary>
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {

        }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        // Auth

        // Finance
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<RecurringTransaction> RecurringTransactions => Set<RecurringTransaction>();

        // Tasks
        public DbSet<Task> Tasks => Set<Task>();

        // Notes
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<Group> Groups => Set<Group>();

        /// <summary>
        /// Configures the schema for the context.<br></br>
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        { }


    }
}
