using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Repository.Employees;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeerepo;
        public IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeerepo,
            IUnitOfWork unitOfWork)
        {
            _employeerepo = employeerepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Employee> InsertNewEmployeeAsync(Employee employee)
        {
            _employeerepo.Add(employee);
            await _unitOfWork.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _employeerepo.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee> GetEmployeeByIdAsync(Guid Id)
        {
            return await _employeerepo.GetByIdAsync(Id);
        }

        public async Task<IPagedList<Employee>> GetAllEmployeesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            return await _employeerepo.GetAllEmployeesPaged(pageIndex, pageSize, orderBy, searchString, searchById);
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            _employeerepo.Delete(employee);
            await _unitOfWork.SaveChangesAsync();
            return 1;
        }



    }
}


