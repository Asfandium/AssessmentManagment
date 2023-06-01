using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using AssessmentMangement.DataContext;

namespace AssessmentMangement.Repository
{
    public abstract class EntityRepositroy<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UpwardsLmsContext _dbContext;
        public EntityRepositroy(UpwardsLmsContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void AddList(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Add(TEntity entity)
        { 
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();

        }

        public void DeleteRange(List<TEntity> entity)
        {
            _dbContext.Set<TEntity>().RemoveRange(entity);
            _dbContext.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ee)
            {
                throw;
            }
        }


        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(Id);

        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

    }
}
