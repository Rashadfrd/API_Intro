using API_Intro.Entities;

namespace APIIntro.DTOs
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
    }
}
