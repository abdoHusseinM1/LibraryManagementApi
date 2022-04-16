using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repo
{
    public class StudentRepo : IStudent
    {

        private readonly StudentDbContext _dp;

        public StudentRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        //get all students
        public IQueryable<Student> GetStudents => _dp.Students;

        //delete
        public void Delete(int? Id)
        {
            Student student = _dp.Students.Find(Id);
            _dp.Students.Remove(student);
            _dp.SaveChanges();
        }

        //get Student by Id
        public Student GetStudent(int? Id)
        {
            Student student = _dp.Students.Find(Id);
            return student;
        }

        //save or update 
        public void Save(Student student)
        {
            if (student.Id == 0)
            {
                _dp.Students.Add(student);
                _dp.SaveChanges();

            }
            else if (student.Id != 0)
            {
                Student _entity = _dp.Students.Find(student.Id);
                _entity.FullName = student.FullName;
                _entity.Address = student.Address;
                _entity.Email = student.Email;
                _entity.Password = student.Password;
                _entity.NationalId = student.NationalId;
                _entity.Phone = student.Phone;
                _entity.IsBlocked = student.IsBlocked;

                _dp.SaveChanges();
            }
        }

        // get length
        public int getLength()
        {
            return _dp.Students.Count();
        }

        // block student
        public void BlockStudent(int? Id)
        {
            _dp.Students.Find(Id).IsBlocked = true;
            _dp.SaveChanges();
        }

        public void AcceptStudent(int? Id)
        {
            _dp.Students.Find(Id).IsAccepted = true;
            _dp.SaveChanges();
        }
    }
}
