using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.Entites.Employees;

namespace AssessmentMangement.Repository.ClassStudentAssessmentResources
{
    public interface IClassStudentAssessmentResourceRepository : IRepository<ClassStudentAssessmentResource>
    {
        Task<IPagedList<ClassStudentAssessmentResource>> GetAllClassStudentAssessmentResourcesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);

        List<ClassStudentAssessmentResource> GetClassStudentAssessmentsResourceByClassStudentAssessmentId(Guid StudentAssessmentId);

        List<ClassStudentAssessmentResource> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId);
    }
}