using AssessmentMangement.DataContext;

namespace AssessmentMangement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UpwardsLmsContext _context;

        public UnitOfWork(UpwardsLmsContext context)
        {
            _context = context;
        }


        /// <summary>
        /// start a new transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction == null)
                _context.Database.BeginTransaction();
        }

        /// <summary>
        /// applies the outstanding operations int the current transaction to the database
        /// </summary>
        public void CommitTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                //audittrail
                _context.Database.CommitTransaction();
            }

        }

        /// <summary>
        /// discard the outstanding operations int the current transaction
        /// </summary>
        public void RollbackTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
                _context.Database.RollbackTransaction();
        }

        /// <summary>
        /// Save all the changes in the database
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Submit and Save all the changes in the db
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            int result = await _context.SaveChangesAsync();
            _context.Database.CommitTransaction();
            return result;
        }
        /// <summary>
        /// Release allocated resources (db context)
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}

