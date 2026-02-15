using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Implements the unit of work pattern for batching database updates into one transaction.
    /// </summary>
    /// <typeparam name="TDbContext">DBContext for EF to use for DB mapping.</typeparam>
    public class UnitOfWorkBase<TDbContext> : IDisposable, IUnitOfWorkBase where TDbContext : DbContext
    {
        protected readonly TDbContext _context;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWorkBase(TDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to 
        /// release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing) { _context.Dispose(); }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources 
        /// related to the context.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>   
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
