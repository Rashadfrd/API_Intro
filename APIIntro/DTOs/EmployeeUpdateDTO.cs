namespace APIIntro.DTOs
{
    public class EmployeeUpdateDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
    }
}
