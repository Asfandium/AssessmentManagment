namespace AssessmentMangement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
        Task<int> SaveChangesAsync();
        void RollbackTransaction();
        void BeginTransaction();
        void CommitTransaction();
    }
}