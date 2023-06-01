namespace AssessmentMangement.Entites.ClassAssessments
{
    public class ClassAssessment : BaseEntity
    {
        public Guid? CourseClassId { get; set; }
        public Guid? ContentRevisionId { get; set; }
        public DateTime? DueDate { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public Decimal? TotalMarks { get; set; }

    }
}