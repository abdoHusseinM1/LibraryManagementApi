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
        IQueryable<Student> GetStudents { get; }
        void Save(Student student);
        void Delete(int? Id);
        int getLength();
        void BlockStudent(int? Id);
        void AcceptStudent(int? Id);
    }
}
