namespace API_Intro.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
