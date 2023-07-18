using MVCDemoNetCore.Models;

namespace MVCDemoNetCore.Interface
{
    public interface IStudentRepository
    {
        Student? GetStudent(int id);
        void Add(Student student);
    }
}
