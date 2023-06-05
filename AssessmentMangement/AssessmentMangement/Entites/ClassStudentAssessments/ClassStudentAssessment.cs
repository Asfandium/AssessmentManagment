namespace AssessmentMangement.Entites.ClassStudentAssessments
{
    public class ClassStudentAssessment : BaseEntity
    {
        public Guid? ClassStudentId { get; set; }
        public Guid? ClassAssessmentId { get; set; }

        public string? AssessmentStatus { get; set; }
        public DateTime? SubmissionDate { get; set; }

       
        public Decimal? ObtainedMarks { get; set; }

        public string? StudentRemarks { get; set; }

        public string? InstructrorRemarks { get; set; }   

    }
}