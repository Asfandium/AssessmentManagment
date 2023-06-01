
using AssessmentMangement.Repository;

using AssessmentMangement.Repository.ClassAssessments;
using AssessmentMangement.Entites.ClassAssessments;

namespace AssessmentMangement.Services.ClassAssessments
{
    public class ClassAssessmentService : IClassAssessmentService
    {
        public IClassAssessmentRepository _classAssessmentRepo;
        public IUnitOfWork _unitOfWork;
        public ClassAssessmentService(IClassAssessmentRepository classAssessmentRepo,
            IUnitOfWork unitOfWork)
        {
            _classAssessmentRepo = classAssessmentRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<ClassAssessment> InsertNewClassAssessmentAsync(ClassAssessment classAssessment)
        {
            _classAssessmentRepo.Add(classAssessment);
            await _unitOfWork.SaveChangesAsync();
            return classAssessment;
        }

        public async Task<ClassAssessment> UpdateClassAssessmentAsync(ClassAssessment classAssessment)
        {
            _classAssessmentRepo.Update(classAssessment);
            await _unitOfWork.SaveChangesAsync();
            return classAssessment;
        }


        public async Task<ClassAssessment> GetClassAssessmentByIdAsync(Guid Id)
        {
            return await _classAssessmentRepo.GetByIdAsync(Id);
        }

        public async Task<IPagedList<ClassAssessment>> GetAllClassAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            return await _classAssessmentRepo.GetAllClassAssessmentsPaged(pageIndex, pageSize, orderBy, searchString, searchById);
        }

        public async Task<int> DeleteClassAssessment(ClassAssessment classAssessment)
        {
            _classAssessmentRepo.Delete(classAssessment);
            await _unitOfWork.SaveChangesAsync();
            return 1;
        }
    }
}


