using AssessmentMangement.Entites.Employees;

namespace AssessmentMangement.Repository.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IPagedList<Employee>> GetAllEmployeesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
       
    }
}
