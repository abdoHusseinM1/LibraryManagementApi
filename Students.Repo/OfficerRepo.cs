using Data;
using Services;
using Students.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class OfficerRepo : IOfficer
    {
        private readonly StudentDbContext _dp;

        //constructor
        public OfficerRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        //get all officers
        public IQueryable<Officer> GetOfficers => _dp.Officers;

        public void AcceptOfficer(int? id)
        {
            _dp.Officers.Find(id).accepted = true;
            _dp.SaveChanges();
        }

        // block officer
        public void BlockOfficer(int? Id)
        {
            _dp.Officers.Find(Id).IsBlocked = true;
            _dp.SaveChanges();
            
        }

        //delete officer
        public void Delete(int? Id)
        {
            Officer officer = _dp.Officers.Find(Id);
            _dp.Officers.Remove(officer);
            _dp.SaveChanges();

        }

        // number of officers
        public int getLength()
        {
            return _dp.Officers.Count();
        }

        // get an officer
        public Officer GetOfficer(int? Id)
        {
            Officer o = _dp.Officers.Find(Id);
            return o;
        }

        // add and update
        public void Save(Officer officer)
        {
            if (officer.Id == 0)
            {
                _dp.Officers.Add(officer);
                _dp.SaveChanges();

            }
            else if (officer.Id != 0)
            {
                Officer _entity = _dp.Officers.Find(officer.Id);
                _entity.FullName = officer.FullName;
                _entity.Address = officer.Address;
                _entity.Email = officer.Email;
                _entity.Password = officer.Password;
                _entity.NationalId = officer.NationalId;
                _entity.IsAdmin = officer.IsAdmin;

                _dp.SaveChanges();
            }
        }

        // make admin
        public void MakeAdmin(int? id)
        {
            _dp.Officers.Find(id).IsAdmin = true;
            _dp.SaveChanges();
        }
    }
}
