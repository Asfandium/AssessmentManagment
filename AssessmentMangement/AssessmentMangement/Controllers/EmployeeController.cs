using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Models.Employees;
using AssessmentMangement.Models.Exceptions;
using AssessmentMangement.Services.Employees;

namespace AssessmentMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        public IEmployeeService _employeeService;
        public IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("/lms/Employee/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {

            if (id == Guid.Empty)
                throw new BadRequestException("invalid id provided");
            var user = _mapper.Map<ResponseEmployee>(await _employeeService.GetEmployeeByIdAsync(id));
            if (user == null)
                throw new EntityNotFoundException();

            return Success(user);
        }
        [HttpGet()]
        [Route("/lms/Employee")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllEmployeeById()
        {

            var employeeList = _mapper.Map<List<ResponseEmployee>>(await _employeeService.GetAllEmployeesPaged(0, int.MaxValue));
            if (employeeList.Count == 0)
                throw new NoContentException();

            return Success(employeeList);
        }

        [HttpPost()]
        [Route("/lms/Employee")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> InsertNewEmployee([FromBody] PutEmployeeRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            Employee employee = _mapper.Map<Employee>(model);

            //Student student = new Student();
            ////student.Id = Guid.Empty;
            //student.StudentName = model.StudentName;
            //student.FatherName = model.FatherName;
            //student.Gender = model.Gender;
            //student.DatetOfBirth = model.DatetOfBirth;
            //student.Address = model.Address;



            await _employeeService.InsertNewEmployeeAsync(employee);
            if (string.IsNullOrEmpty(Convert.ToString(employee.Id)))
                throw new InternalServerException();
            return CreatedWithId(Convert.ToString(employee.Id), $"/api/lms/Employee/{employee.Id}");
        }
        [HttpPut()]
        [Route("/lms/Employee/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] PutEmployeeRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            //Employee std = _mapper.Map<Employee>(model);

            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee.Id == Guid.Empty)
                throw new EntityNotFoundException();




            _mapper.Map(model, employee);


            await _employeeService.UpdateEmployeeAsync(employee);
            if (string.IsNullOrEmpty(Convert.ToString(employee.Id)))
                throw new InternalServerException();
            return Success();
        }
        [HttpDelete()]
        [Route("/lms/Employee/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new EntityNotFoundException();
            await _employeeService.DeleteEmployee(employee);
            return Success();
        }
    }
}