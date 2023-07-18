using MVCDemoNetCore.Util;

namespace MVCDemoNetCore.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ClassName? ClassName { get; set; }
        public string? Email { get; set; }
    }
}
