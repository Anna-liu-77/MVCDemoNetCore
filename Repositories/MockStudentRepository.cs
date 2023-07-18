using MVCDemoNetCore.Interface;
using MVCDemoNetCore.Models;
using MVCDemoNetCore.Util;
using System.Collections.Generic;
using System.Linq;

namespace MVCDemoNetCore.Repositories
{
    public class MockStudentRepository : IStudentRepository
    {
        public List<Student> _studentList;

        public MockStudentRepository()
        {
            // 硬编码
            _studentList = new List<Student>()
            {
                new Student() {Id=1, Name="zhangyi", ClassName = ClassName.GradeOne, Email="zhang@test.com"},
                new Student() {Id=2, Name="zhanger", ClassName = ClassName.GradeOne, Email="zhang@test.com"},
                new Student() {Id=3, Name="zhangsan", ClassName = ClassName.GradeOne, Email="zhang@test.com"},
            };
        }

        public Student? GetStudent(int id)
        {
            // or: return _studentList[id];
            return _studentList.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Student stu)
        {
            var id = _studentList.Max(x => x.Id) +1;
            stu.Id = id;
            _studentList.Add(stu);
        }
    }
}
