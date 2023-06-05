namespace AssessmentMangement.Entites.ClassStudentAssessmentResources
{
    public class ClassStudentAssessmentResource : BaseEntity
    {
        public Guid? ClassStudentAssessmentId { get; set; }
        public Guid? DocumentId { get; set; }

        public string? ResourceType { get; set; }
       
    }
}