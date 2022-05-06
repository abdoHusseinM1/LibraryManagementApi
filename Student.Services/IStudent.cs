using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Data;

namespace Students.Services
{
    public interface IStudent
    {
        Student GetStudent(int? Id);
        List<Student> GetStudents { get; }
        List<Student> GetStudentRequests();
        void AddStudent(Student student);
        void EditStudent (Student student);
        void Delete(int? Id);
        int getLength();
        void BlockStudent(int? Id);
        void AcceptStudent(int? Id);
        Student GetStudentByEmail(String email);
    }
}
