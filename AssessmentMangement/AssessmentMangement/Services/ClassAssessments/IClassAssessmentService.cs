using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Repository;
using System.Reflection.Metadata;

namespace AssessmentMangement.Services.ClassAssessments
{
    public interface IClassAssessmentService
    {

        Task<ClassAssessment> InsertNewClassAssessmentAsync(ClassAssessment classAssessment);
        Task<ClassAssessment> UpdateClassAssessmentAsync(ClassAssessment classAssessment);
        Task<ClassAssessment> GetClassAssessmentByIdAsync(Guid Id);
        Task<IPagedList<ClassAssessment>> GetAllClassAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
        Task<int> DeleteClassAssessment(ClassAssessment classAssessment);
        List<ClassAssessment> GetClassAssessmentByCourseClassId(Guid courseClassId);

        List<ClassAssessment> GetClassAssessmentByContentRevisionId(Guid contentnRevisionId);



    }
}
