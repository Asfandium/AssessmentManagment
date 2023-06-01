using AssessmentMangement.Entites;

namespace AssessmentMangement.Models.ClassAssessments
{
    public class PutClassAssessmentRequest 
    {
        public Guid? CourseClassId { get; set; }
        public Guid? ContentRevisionId { get; set; }
        public DateTime? DueDate { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public Decimal? TotalMarks { get; set; }

    }
}