using System.ComponentModel.DataAnnotations;

namespace AssessmentMangement.Models
{
    public class BaseEntityModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
