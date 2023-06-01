using AssessmentMangement.DataContext;
using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Infrastructure;
using AssessmentMangement.Repository.Employees;

namespace AssessmentMangement.Repository.ClassAssessments
{
    public class ClassAssessmentRepository : EntityRepositroy<ClassAssessment>, IClassAssessmentRepository
    {
        public ClassAssessmentRepository(UpwardsLmsContext context) : base(context)
        {
        }
        public async Task<IPagedList<ClassAssessment>> GetAllClassAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            var query = _dbContext.ClassAssessments.AsQueryable();
            if (searchById != null)
            {
                Guid id = Guid.Parse(searchById);
                query = query.Where(j => j.Id == id);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                char[] chars = { ' ', ',', '.', ';' };
                var filters = searchString.Split(chars);
                foreach (var term in filters)
                {
                    query = query.Where(j => (Convert.ToString(j.CourseClassId)).Contains(term));
                }
            }
            query = query.Sort(orderBy);
            var result = await query.ToPagedListAsync(pageIndex, pageSize);
            return result;

        }
    }
}