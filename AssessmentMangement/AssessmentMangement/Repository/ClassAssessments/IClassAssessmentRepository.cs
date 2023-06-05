using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;
using System.Reflection.Metadata;

namespace AssessmentMangement.Repository.ClassAssessments
{
    public interface IClassAssessmentRepository : IRepository<ClassAssessment>
    {
        Task<IPagedList<ClassAssessment>> GetAllClassAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);

        List<ClassAssessment> GetClassAssessmentByCourseClassId(Guid courseClassId);

        List<ClassAssessment> GetClassAssessmentByContentRevisionId(Guid contentnRevisionId);
    }
}
