namespace AssessmentMangement.Models.Employees
{
    public class ResponseEmployee : BaseEntityModel
    {
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public int? Salary { get; set; }

    }
}