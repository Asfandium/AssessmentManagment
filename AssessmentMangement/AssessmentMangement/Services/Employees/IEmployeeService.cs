using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Services.Employees
{
    public interface IEmployeeService
    {
        Task<Employee> InsertNewEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(Guid Id);
        Task<IPagedList<Employee>> GetAllEmployeesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
        Task<int> DeleteEmployee(Employee employee);

    }
}
