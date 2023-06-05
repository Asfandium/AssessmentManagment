using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Repository.ClassStudentAssessments;
using AssessmentMangement.Repository;
using AssessmentMangement.Services.ClassStudentAssessments;
using AssessmentMangement.Repository.ClassStudentAssessmentResources;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;

namespace AssessmentMangement.Services.ClassStudentAssessmentResources
{
    public class ClassStudentAssessmentResourceService : IClassStudentAssessmentResourceService
    {
        public IClassStudentAssessmentResourceRepository _classStudentAssessmentResourceRepo;
        public IUnitOfWork _unitOfWork;
        public ClassStudentAssessmentResourceService(IClassStudentAssessmentResourceRepository classStudentAssessmentResourceRepo,
            IUnitOfWork unitOfWork)
        {
            _classStudentAssessmentResourceRepo = classStudentAssessmentResourceRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<ClassStudentAssessmentResource> InsertNewClassStudentAssessmentResourceAsync(ClassStudentAssessmentResource classStudentAssessmentResource)
        {
            _classStudentAssessmentResourceRepo.Add(classStudentAssessmentResource);
            await _unitOfWork.SaveChangesAsync();
            return classStudentAssessmentResource;
        }

        public async Task<ClassStudentAssessmentResource> UpdateClassStudentAssessmentResourceAsync(ClassStudentAssessmentResource classStudentAssessmentResource)
        {
            _classStudentAssessmentResourceRepo.Update(classStudentAssessmentResource);
            await _unitOfWork.SaveChangesAsync();
            return classStudentAssessmentResource;
        }


        public async Task<ClassStudentAssessmentResource> GetClassStudentAssessmentResourceByIdAsync(Guid Id)
        {
            return await _classStudentAssessmentResourceRepo.GetByIdAsync(Id);
        }

        public async Task<IPagedList<ClassStudentAssessmentResource>> GetAllClassStudentAssessmentResourcesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            return await _classStudentAssessmentResourceRepo.GetAllClassStudentAssessmentResourcesPaged(pageIndex, pageSize, orderBy, searchString, searchById);
        }

        public async Task<int> DeleteClassStudentAssessmentResource(ClassStudentAssessmentResource classStudentAssessmentResource)
        {
            _classStudentAssessmentResourceRepo.Delete(classStudentAssessmentResource);
            await _unitOfWork.SaveChangesAsync();
            return 1;
        }



        public List<ClassStudentAssessmentResource> GetClassStudentAssessmentsResourceByClassStudentAssessmentId(Guid StudentAssessmentId)
        {
            return _classStudentAssessmentResourceRepo.GetClassStudentAssessmentsResourceByClassStudentAssessmentId(StudentAssessmentId);
        }



        public List<ClassStudentAssessmentResource> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId)
        {
            return _classStudentAssessmentResourceRepo.GetClassStudentAssessmentResourcesByDocumentId(documentId);
        }

    }
}


