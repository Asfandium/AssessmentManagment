using AssessmentMangement.DataContext;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Infrastructure;

namespace AssessmentMangement.Repository.Employees
{
    public class EmployeeRepository : EntityRepositroy<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(UpwardsLmsContext context) : base(context)
        {
        }
        public async Task<IPagedList<Employee>> GetAllEmployeesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            var query = _dbContext.Employees.AsQueryable();
            if (searchById != null)
            {
                Guid id = Guid.Parse(searchById);
                query = query.Where(j => j.Id == id);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                char[] chars = { ' ', ',', '.', ';' };
                var filters = searchString.Split(chars);
                foreach (var term in filters)
                {
                    query = query.Where(j => (j.Name).Contains(term));
                }
            }
            query = query.Sort(orderBy);
            var result = await query.ToPagedListAsync(pageIndex, pageSize);
            return result;

        }
    }
}