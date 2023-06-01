using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.Models.ClassAssessments;
using AssessmentMangement.Models.Employees;

namespace AssessmentMangement.Mapper
{
    public class UpwardsLmsMapper:AutoMapper.Profile
    {
       public UpwardsLmsMapper()
        {


            CreateMap<Employee, PutEmployeeRequest>();
            CreateMap<PutEmployeeRequest, Employee>();
            CreateMap<Employee, ResponseEmployee>();
            CreateMap<ResponseEmployee, Employee>();



            CreateMap<ClassAssessment, PutClassAssessmentRequest>();
            CreateMap<PutClassAssessmentRequest, ClassAssessment>();
            CreateMap<ClassAssessment, ResponseClassAssessment>();
            CreateMap<ResponseClassAssessment, ClassAssessment>();




        }
    }
}
