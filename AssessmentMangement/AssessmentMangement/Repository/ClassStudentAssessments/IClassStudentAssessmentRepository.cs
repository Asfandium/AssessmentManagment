using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Entites.Employees;

namespace AssessmentMangement.Repository.ClassStudentAssessments
{
    public interface IClassStudentAssessmentRepository : IRepository<ClassStudentAssessment>
    {
        Task<IPagedList<ClassStudentAssessment>> GetAllClassStudentAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);

        List<ClassStudentAssessment> GetClassStudentAssessmentsByStudentId(Guid StudentId);

        List<ClassStudentAssessment> GetClassStudentAssessmentsByClassAssessmentId(Guid ClassAssessmentId);
    }
}