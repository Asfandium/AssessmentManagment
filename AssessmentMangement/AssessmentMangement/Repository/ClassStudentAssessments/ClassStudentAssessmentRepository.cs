using AssessmentMangement.DataContext;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Infrastructure;
using AssessmentMangement.Repository.Employees;
using System.Reflection.Metadata;

namespace AssessmentMangement.Repository.ClassStudentAssessments
{
    public class ClassStudentAssessmentRepository : EntityRepositroy<ClassStudentAssessment>, IClassStudentAssessmentRepository
    {
        public ClassStudentAssessmentRepository(UpwardsLmsContext context) : base(context)
        {
        }
        public async Task<IPagedList<ClassStudentAssessment>> GetAllClassStudentAssessmentsPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            var query = _dbContext.ClassStudentAssessments.AsQueryable();
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
                    query = query.Where(j => (Convert.ToString(j.ClassStudentId)).Contains(term));
                }
            }
            query = query.Sort(orderBy);
            var result = await query.ToPagedListAsync(pageIndex, pageSize);
            return result;

        }

       
        public List<ClassStudentAssessment> GetClassStudentAssessmentsByStudentId(Guid StudentId)
        {
            return _dbContext.ClassStudentAssessments
                .Where(d => d.ClassStudentId == StudentId)
                .ToList();
        }


        public List<ClassStudentAssessment> GetClassStudentAssessmentsByClassAssessmentId(Guid ClassAssessmentId)
        {
            return _dbContext.ClassStudentAssessments
                .Where(d => d.ClassAssessmentId== ClassAssessmentId)
                .ToList();
        }

    }
}