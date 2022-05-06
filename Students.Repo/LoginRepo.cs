using Data.Models;
using Repos_Interfaces;
using Students.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos_Implementation
{
    public class LoginRepo : ILogin
    {
        StudentDbContext _dp;
        public LoginRepo (StudentDbContext dp)
        {
            this._dp = dp;
        }
        public int LoginOfficer(LoginUser user)
        {
            var officers = _dp.Officers.ToList();
            if (officers.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < officers.Count; i++)
            {
                if (user.Password == officers[i].Password && user.Email == officers[i].Email)
                {
                    return 0;
                }
            }
            return -1;
        }

        public int LoginStudent(LoginUser user)
        {
            var students = _dp.Students.ToList();
            students.AsReadOnly();
            if (students.Count == 0)
            {
                return -1;
            }
                for (int i = 0; i < students.Count; i++)
                {
                    bool v = user.Password == students[i].Password;
                    bool v1 = user.Email == students[i].Email;
                    if (v && v1)
                    {
                        return 0;
                    }
                }
            
            return -1;
        }
    }
}
