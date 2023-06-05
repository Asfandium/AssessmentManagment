using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Services.ClassStudentAssessments
{
    public interface IClassStudentAssessmentService
    {
        Task<ClassStudentAssessment> InsertNewClassStudentAssessmentAsync(ClassStudentAssessment classStudentAssessment);
        Task<ClassStudentAssessment> UpdateClassStudentAssessmentAsync(ClassStudentAssessment classStudentAssessment);
        Task<ClassStudentAssessment> GetClassStudentAssessmentByIdAsync(Guid Id);
        Task<IPagedList<ClassStudentAssessment>> GetAllClassStudentAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
        Task<int> DeleteClassStudentAssessment(ClassStudentAssessment classStudentAssessment);
        List<ClassStudentAssessment> GetClassStudentAssessmentsByStudentId(Guid StudentId);

        List<ClassStudentAssessment> GetClassStudentAssessmentsByClassAssessmentId(Guid ClassAssessmentId);


    }
}
