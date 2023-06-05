using AssessmentMangement.Entites;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Models.ClassStudentAssessmentResources;
using AssessmentMangement.Models.ClassStudentAssessments;
using AssessmentMangement.Models.Exceptions;
using AssessmentMangement.Services.ClassStudentAssessmentResources;
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
    public class ClassStudentAssessmentResourceController : BaseApiController
    {
        public IClassStudentAssessmentResourceService _classStudentAssessmentResourceService;
        public IMapper _mapper;

        public ClassStudentAssessmentResourceController(IClassStudentAssessmentResourceService classStudentAssessmentResourceService, IMapper mapper)
        {
            _classStudentAssessmentResourceService = classStudentAssessmentResourceService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("/lms/ClassStudentAssessmentResource/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetClassStudentAssessmentResourceById(Guid id)
        {

            if (id == Guid.Empty)
                throw new BadRequestException("invalid id provided");
            var user = _mapper.Map<ResponseClassStudentAssessmentResource>(await _classStudentAssessmentResourceService.GetClassStudentAssessmentResourceByIdAsync(id));
            if (user == null)
                throw new EntityNotFoundException();

            return Success(user);
        }
        [HttpGet()]
        [Route("/lms/ClassStudentAssessmentResource")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllClassStudentAssessmentResourceById()
        {

            var classStudentAssessmentResourceList = _mapper.Map<List<ResponseClassStudentAssessmentResource>>(await _classStudentAssessmentResourceService.GetAllClassStudentAssessmentResourcesPaged(0, int.MaxValue));
            if (classStudentAssessmentResourceList.Count == 0)
                throw new NoContentException();

            return Success(classStudentAssessmentResourceList);
        }

        [HttpPost()]
        [Route("/lms/ClassStudentAssessmentResource")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> InsertNewClassStudentAssessmentResource([FromBody] PutClassStudentAssessmentResourceRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();
            ClassStudentAssessmentResource classStudentAssessmentResource = _mapper.Map<ClassStudentAssessmentResource>(model);





            await _classStudentAssessmentResourceService.InsertNewClassStudentAssessmentResourceAsync(classStudentAssessmentResource);
            if (string.IsNullOrEmpty(Convert.ToString(classStudentAssessmentResource.Id)))
                throw new InternalServerException();
            return CreatedWithId(Convert.ToString(classStudentAssessmentResource.Id), $"/api/lms/ClassStudentAssessmentResource/{classStudentAssessmentResource.Id}");
        }
        [HttpPut()]
        [Route("/lms/ClassStudentAssessmentResource/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateClassStudentAssessmentResource(Guid id, [FromBody] PutClassStudentAssessmentResourceRequest model)
        {
            if (model == null)
                throw new ArgumentNullException();


            var classStudentAssessmentResource = await _classStudentAssessmentResourceService.GetClassStudentAssessmentResourceByIdAsync(id);
            if (classStudentAssessmentResource.Id == Guid.Empty)
                throw new EntityNotFoundException();




            _mapper.Map(model, classStudentAssessmentResource);


            await _classStudentAssessmentResourceService.UpdateClassStudentAssessmentResourceAsync(classStudentAssessmentResource);
            if (string.IsNullOrEmpty(Convert.ToString(classStudentAssessmentResource.Id)))
                throw new InternalServerException();
            return Success();
        }
        [HttpDelete()]
        [Route("/lms/ClassStudentAssessmentResource/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteClassStudentAssessmentResource(Guid id)
        {
            var classStudentAssessmentResource = await _classStudentAssessmentResourceService.GetClassStudentAssessmentResourceByIdAsync(id);
            if (classStudentAssessmentResource == null)
                throw new EntityNotFoundException();
            await _classStudentAssessmentResourceService.DeleteClassStudentAssessmentResource(classStudentAssessmentResource);
            return Success();
        }




        [HttpGet()]
        [Route("/lms/ClassStudentAssessmentResource/GetClassStudentAssessmentsResourceByClassStudentAssessmentId/StudentId")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<List<ClassStudentAssessmentResource>> GetClassStudentAssessmentsResourceByClassStudentAssessmentId(Guid StudentAssessmentId)
        {
            List<ClassStudentAssessmentResource> classStudentAssessmentResource = _classStudentAssessmentResourceService.GetClassStudentAssessmentsResourceByClassStudentAssessmentId(StudentAssessmentId);

            if (classStudentAssessmentResource == null || classStudentAssessmentResource.Count == 0)
            {
                return NotFound();
            }

            return Ok(classStudentAssessmentResource);
        }


        //List<ClassStudentAssessmentResource> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId)

        [HttpGet()]
        [Route("/lms/ClassStudentAssessmentResource/GetClassStudentAssessmentResourcesByDocumentId/documentId")]
        [Produces(MediaTypeNames.Application.Json)]

        public ActionResult<List<ClassStudentAssessmentResource>> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId)
        {
            List<ClassStudentAssessmentResource> classStudentAssessmentResource = _classStudentAssessmentResourceService.GetClassStudentAssessmentResourcesByDocumentId(documentId);

            if (classStudentAssessmentResource == null || classStudentAssessmentResource.Count == 0)
            {
                return NotFound();
            }

            return Ok(classStudentAssessmentResource);
        }




    }
}