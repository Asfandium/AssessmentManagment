using AssessmentMangement.Entites;

namespace AssessmentMangement.Models.ClassStudentAssessmentResources
{
    public class PutClassStudentAssessmentResourceRequest 
    {
        public Guid? ClassStudentAssessmentId { get; set; }
        public Guid? DocumentId { get; set; }

        public string? ResourceType { get; set; }

    }
}