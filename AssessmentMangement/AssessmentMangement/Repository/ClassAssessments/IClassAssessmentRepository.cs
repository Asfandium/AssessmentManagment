using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;

namespace AssessmentMangement.Repository.ClassAssessments
{
    public interface IClassAssessmentRepository : IRepository<ClassAssessment>
    {
        Task<IPagedList<ClassAssessment>> GetAllClassAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null);
    }
}
