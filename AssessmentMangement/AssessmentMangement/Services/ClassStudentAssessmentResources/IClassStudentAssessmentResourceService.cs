using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Services.ClassStudentAssessmentResources
{
    public interface IClassStudentAssessmentResourceService
    {
        Task<ClassStudentAssessmentResource> InsertNewClassStudentAssessmentResourceAsync(ClassStudentAssessmentResource classStudentAssessmentResource);
        Task<ClassStudentAssessmentResource> UpdateClassStudentAssessmentResourceAsync(ClassStudentAssessmentResource classStudentAssessmentResource);
        Task<ClassStudentAssessmentResource> GetClassStudentAssessmentResourceByIdAsync(Guid Id);
        Task<IPagedList<ClassStudentAssessmentResource>> GetAllClassStudentAssessmentResourcesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
        Task<int> DeleteClassStudentAssessmentResource(ClassStudentAssessmentResource classStudentAssessmentResource);

        List<ClassStudentAssessmentResource> GetClassStudentAssessmentsResourceByClassStudentAssessmentId(Guid StudentAssessmentId);

        List<ClassStudentAssessmentResource> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId);

    }
}
