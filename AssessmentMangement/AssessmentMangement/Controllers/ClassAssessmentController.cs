using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Models.ClassAssessments;
using AssessmentMangement.Models.Employees;
using AssessmentMangement.Models.Exceptions;
using AssessmentMangement.Services.ClassAssessments;
using AssessmentMangement.Services.Employees;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Reflection.Metadata;

namespace AssessmentMangement.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClassAssessmentController : BaseApiController
    {
        public IClassAssessmentService _classAssessmentService;
        public IMapper _mapper;

        public ClassAssessmentController(IClassAssessmentService classAssessmentService, IMapper mapper)
        {
            _classAssessmentService = classAssessmentService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("/lms/ClassAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetClassAssessmentById(Guid id)
        {

            if (id == Guid.Empty)
                throw new BadRequestException("invalid id provided");
            var user = _mapper.Map<ResponseClassAssessment>(await _classAssessmentService.GetClassAssessmentByIdAsync(id));
            if (user == null)
                throw new EntityNotFoundException();

            return Success(user);
        }
        [HttpGet()]
        [Route("/lms/ClassAssessment")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllClassAssessmentById()
        {

            var classAssessmentList = _mapper.Map<List<ResponseClassAssessment>>(await _classAssessmentService.GetAllClassAssessmentsPaged(0, int.MaxValue));
            if (classAssessmentList.Count == 0)
                throw new NoContentException();

            return Success(classAssessmentList);
        }

        [HttpPost()]
        [Route("/lms/ClassAssessment")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> InsertNewClassAssessment([FromBody] PutClassAssessmentRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            ClassAssessment classAssessment = _mapper.Map<ClassAssessment>(model);

            //Student student = new Student();
            ////student.Id = Guid.Empty;
            //student.StudentName = model.StudentName;
            //student.FatherName = model.FatherName;
            //student.Gender = model.Gender;
            //student.DatetOfBirth = model.DatetOfBirth;
            //student.Address = model.Address;



            await _classAssessmentService.InsertNewClassAssessmentAsync(classAssessment);
            if (string.IsNullOrEmpty(Convert.ToString(classAssessment.Id)))
                throw new InternalServerException();
            return CreatedWithId(Convert.ToString(classAssessment.Id), $"/api/lms/ClassAssessment/{classAssessment.Id}");
        }
        [HttpPut()]
        [Route("/lms/ClassAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateClassAssessment(Guid id, [FromBody] PutClassAssessmentRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            //Employee std = _mapper.Map<Employee>(model);

            var classAssessment = await _classAssessmentService.GetClassAssessmentByIdAsync(id);
            if (classAssessment.Id == Guid.Empty)
                throw new EntityNotFoundException();




            _mapper.Map(model, classAssessment);


            await _classAssessmentService.UpdateClassAssessmentAsync(classAssessment);
            if (string.IsNullOrEmpty(Convert.ToString(classAssessment.Id)))
                throw new InternalServerException();
            return Success();
        }
        [HttpDelete()]
        [Route("/lms/ClassAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteClassAssessment(Guid id)
        {
            var classAssessment = await _classAssessmentService.GetClassAssessmentByIdAsync(id);
            if (classAssessment == null)
                throw new EntityNotFoundException();
            await _classAssessmentService.DeleteClassAssessment(classAssessment);
            return Success();

 
        }



        [HttpGet()]
        [Route("/lms/ClassAssessment/GetClassAssessmentByCourseClassId/courseClassId")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<List<ClassAssessment>> GetClassAssessmentByCourseClassId(Guid courseClassId)
        {
            List<ClassAssessment> classAssessment = _classAssessmentService.GetClassAssessmentByCourseClassId(courseClassId);

            if (classAssessment == null || classAssessment.Count == 0)
            {
                return NotFound();
            }

            return Ok(classAssessment);
        }



        [HttpGet()]
        [Route("/lms/ClassAssessment/GetClassAssessmentByContentRevisionId/contentnRevisionId")]
        [Produces(MediaTypeNames.Application.Json)]

        public ActionResult<List<ClassAssessment>> GetClassAssessmentByContentRevisionId(Guid contentnRevisionId)
        {
            List<ClassAssessment> classAssessment = _classAssessmentService.GetClassAssessmentByContentRevisionId(contentnRevisionId);

            if (classAssessment == null || classAssessment.Count == 0)
            {
                return NotFound();
            }

            return Ok(classAssessment);
        }



    }
}