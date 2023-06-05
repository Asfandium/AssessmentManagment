using AssessmentMangement.Entites;

namespace AssessmentMangement.Models.ClassAssessments
{
    public class ResponseClassAssessment : BaseEntityModel
    {
        public Guid? CourseClassId { get; set; }
        public Guid? ContentRevisionId { get; set; }
        public DateTime? DueDate { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public Decimal? TotalMarks { get; set; }

    }
}