using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Models.ClassStudentAssessments;
using AssessmentMangement.Models.Exceptions;
using AssessmentMangement.Services.ClassStudentAssessments;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Reflection.Metadata;

namespace AssessmentMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassStudentAssessmentController : BaseApiController
    {
        public IClassStudentAssessmentService _classStudentAssessmentService;
        public IMapper _mapper;

        public ClassStudentAssessmentController(IClassStudentAssessmentService classStudentAssessmentService, IMapper mapper)
        {
            _classStudentAssessmentService = classStudentAssessmentService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("/lms/ClassStudentAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetClassStudentAssessmentById(Guid id)
        {

            if (id == Guid.Empty)
                throw new BadRequestException("invalid id provided");
            var user = _mapper.Map<ResponseClassStudentAssessment>(await _classStudentAssessmentService.GetClassStudentAssessmentByIdAsync(id));
            if (user == null)
                throw new EntityNotFoundException();

            return Success(user);
        }
        [HttpGet()]
        [Route("/lms/ClassStudentAssessment")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllClassStudentAssessmentById()
        {

            var classStudentAssessmentList = _mapper.Map<List<ResponseClassStudentAssessment>>(await _classStudentAssessmentService.GetAllClassStudentAssessmentsPaged(0, int.MaxValue));
            if (classStudentAssessmentList.Count == 0)
                throw new NoContentException();

            return Success(classStudentAssessmentList);
        }

        [HttpPost()]
        [Route("/lms/ClassStudentAssessment")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> InsertNewClassStudentAssessment([FromBody] PutClassStudentAssessmentRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            ClassStudentAssessment classStudentAssessment = _mapper.Map<ClassStudentAssessment>(model);

                      



            await _classStudentAssessmentService.InsertNewClassStudentAssessmentAsync(classStudentAssessment);
            if (string.IsNullOrEmpty(Convert.ToString(classStudentAssessment.Id)))
                throw new InternalServerException();
            return CreatedWithId(Convert.ToString(classStudentAssessment.Id), $"/api/lms/ClassStudentAssessment/{classStudentAssessment.Id}");
        }
        [HttpPut()]
        [Route("/lms/ClassStudentAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateClassStudentAssessment(Guid id, [FromBody] PutClassStudentAssessmentRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
           

            var classStudentAssessment = await _classStudentAssessmentService.GetClassStudentAssessmentByIdAsync(id);
            if (classStudentAssessment.Id == Guid.Empty)
                throw new EntityNotFoundException();




            _mapper.Map(model, classStudentAssessment);


            await _classStudentAssessmentService.UpdateClassStudentAssessmentAsync(classStudentAssessment);
            if (string.IsNullOrEmpty(Convert.ToString(classStudentAssessment.Id)))
                throw new InternalServerException();
            return Success();
        }
        [HttpDelete()]
        [Route("/lms/ClassStudentAssessment/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteClassStudentAssessment(Guid id)
        {
            var classStudentAssessment = await _classStudentAssessmentService.GetClassStudentAssessmentByIdAsync(id);
            if (classStudentAssessment == null)
                throw new EntityNotFoundException();
            await _classStudentAssessmentService.DeleteClassStudentAssessment(classStudentAssessment);
            return Success();
        }




        [HttpGet()]
        [Route("/lms/ClassStudentAssessment/GetClassStudentAssessmentsByStudentId/StudentId")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<List<ClassStudentAssessment>> GetClassStudentAssessmentsByStudentId(Guid StudentId)
        {
            List<ClassStudentAssessment> classStudentAssessment = _classStudentAssessmentService.GetClassStudentAssessmentsByStudentId(StudentId);

            if (classStudentAssessment == null || classStudentAssessment.Count == 0)
            {
                return NotFound();
            }

            return Ok(classStudentAssessment);
        }

        

        [HttpGet()]
        [Route("/lms/ClassStudentAssessment/GetClassStudentAssessmentsByClassAssessmentId/ClassAssessmentId")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<List<ClassStudentAssessment>> GetClassStudentAssessmentsByClassAssessmentId(Guid ClassAssessmentId)
        {
            List<ClassStudentAssessment> classStudentAssessment = _classStudentAssessmentService.GetClassStudentAssessmentsByClassAssessmentId(ClassAssessmentId);

            if (classStudentAssessment == null || classStudentAssessment.Count == 0)
            {
                return NotFound();
            }

            return Ok(classStudentAssessment);
        }
    }
}