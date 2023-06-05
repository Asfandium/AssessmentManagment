using AssessmentMangement.DataContext;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Infrastructure;
using AssessmentMangement.Repository.Employees;
using System.Reflection.Metadata;

namespace AssessmentMangement.Repository.ClassStudentAssessmentResources
{
    public class ClassStudentAssessmentResourceRepository : EntityRepositroy<ClassStudentAssessmentResource>, IClassStudentAssessmentResourceRepository
    {
        public ClassStudentAssessmentResourceRepository(UpwardsLmsContext context) : base(context)
        {
        }
        public async Task<IPagedList<ClassStudentAssessmentResource>> GetAllClassStudentAssessmentResourcesPaged(int pageIndex, int pageSize, string orderBy = "", string searchString = "", string searchById = null)
        {
            var query = _dbContext.ClassStudentAssessmentResources.AsQueryable();
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
                    query = query.Where(j => (Convert.ToString(j.ClassStudentAssessmentId)).Contains(term));
                }
            }
            query = query.Sort(orderBy);
            var result = await query.ToPagedListAsync(pageIndex, pageSize);
            return result;

        }


        public List<ClassStudentAssessmentResource> GetClassStudentAssessmentsResourceByClassStudentAssessmentId(Guid StudentAssessmentId)
        {
            return _dbContext.ClassStudentAssessmentResources
                .Where(d => d.ClassStudentAssessmentId == StudentAssessmentId)
                .ToList();
        }


        public List<ClassStudentAssessmentResource> GetClassStudentAssessmentResourcesByDocumentId(Guid documentId)
        {
            return _dbContext.ClassStudentAssessmentResources
                .Where(d => d.DocumentId == documentId)
                .ToList();
        }


    }
}