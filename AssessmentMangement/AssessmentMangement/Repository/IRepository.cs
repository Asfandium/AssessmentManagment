namespace AssessmentMangement.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {

        void Update(TEntity entity);
        void Add(TEntity entity);
        void AddList(List<TEntity> entities);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entity);
       
    }
}
