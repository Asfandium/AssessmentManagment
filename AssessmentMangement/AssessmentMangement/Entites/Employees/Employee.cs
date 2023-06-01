namespace AssessmentMangement.Entites.Employees
{
    public class Employee : BaseEntity
    {
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public int? Salary { get; set; }
       
    }
}