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
        public List<Student> GetStudents => _dp.Students.ToList();

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
        public void AddStudent(Student student)
        {
            if (student.Id == 0)
            {
                _dp.Students.Add(student);
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
            if(_dp.Students.Find(Id) != null)
            {
                _dp.Students.Find(Id).IsBlocked = true;
                _dp.SaveChanges();
            }
            
        }

        public void AcceptStudent(int? Id)
        {
            _dp.Students.Find(Id).IsAccepted = true;
            _dp.SaveChanges();
        }

        public void EditStudent(Student student)
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

        public List<Student> GetStudentRequests()
        {
            var a = _dp.Students.Where(c => c.IsAccepted == false && c.IsBlocked == false).ToList();
            return a;
        }

        public Student GetStudentByEmail(string email)
        {
            Student s = _dp.Students.Where(c => c.Email == email).FirstOrDefault();
            return s;
        }
    }
}
