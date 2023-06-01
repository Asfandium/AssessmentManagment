namespace AssessmentMangement.Entites
{
    public class User:BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? UserEmail { get; set; }

        public string? UserPassword { get; set; }

        public string? UserStatus { get; set; }

        public DateTime? VerificationDate { get; set; }

        public string? UserAccountType { get; set; }

        public Guid? AvatarDocumentId { get; set; }

        public string? Description { get; set; }
    }
}
