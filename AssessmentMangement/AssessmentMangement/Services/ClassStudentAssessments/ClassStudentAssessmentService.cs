
using AssessmentMangement.Repository;
using AssessmentMangement.Repository.ClassStudentAssessments;
using AssessmentMangement.Entites.ClassStudentAssessments;
using System.Reflection.Metadata;

namespace AssessmentMangement.Services.ClassStudentAssessments
{
    //ClassStudentAssessment
    public class ClassStudentAssessmentService : IClassStudentAssessmentService
    {
        public IClassStudentAssessmentRepository _classStudentAssessmentRepo;
        public IUnitOfWork _unitOfWork;
        public ClassStudentAssessmentService(IClassStudentAssessmentRepository classStudentAssessmentRepo,
            IUnitOfWork unitOfWork)
        {
            _classStudentAssessmentRepo = classStudentAssessmentRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<ClassStudentAssessment> InsertNewClassStudentAssessmentAsync(ClassStudentAssessment classStudentAssessment)
        {
            _classStudentAssessmentRepo.Add(classStudentAssessment);
            await _unitOfWork.SaveChangesAsync();
            return classStudentAssessment;
        }

        public async Task<ClassStudentAssessment> UpdateClassStudentAssessmentAsync(ClassStudentAssessment classStudentAssessment)
        {
            _classStudentAssessmentRepo.Update(classStudentAssessment);
            await _unitOfWork.SaveChangesAsync();
            return classStudentAssessment;
        }


        public async Task<ClassStudentAssessment> GetClassStudentAssessmentByIdAsync(Guid Id)
        {
            return await _classStudentAssessmentRepo.GetByIdAsync(Id);
        }

        public async Task<IPagedList<ClassStudentAssessment>> GetAllClassStudentAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            return await _classStudentAssessmentRepo.GetAllClassStudentAssessmentsPaged(pageIndex, pageSize, orderBy, searchString, searchById);
        }

        public async Task<int> DeleteClassStudentAssessment(ClassStudentAssessment classStudentAssessment)
        {
            _classStudentAssessmentRepo.Delete(classStudentAssessment);
            await _unitOfWork.SaveChangesAsync();
            return 1;
        }

        public List<ClassStudentAssessment> GetClassStudentAssessmentsByStudentId(Guid StudentId)
        {
            return _classStudentAssessmentRepo.GetClassStudentAssessmentsByStudentId(StudentId);
        }



        public List<ClassStudentAssessment> GetClassStudentAssessmentsByClassAssessmentId(Guid ClassAssessmentId)
        {
            return _classStudentAssessmentRepo.GetClassStudentAssessmentsByClassAssessmentId(ClassAssessmentId);
        }

    }
}


