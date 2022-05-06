using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOfficer
    {
        Officer GetOfficer(int? Id);
        IQueryable<Officer> GetOfficers { get; }
        void Save(Officer officer);
        void Delete(int? Id);
        int getLength();
        void BlockOfficer(int? Id);
        void AcceptOfficer(int? id);
        void MakeAdmin(int? id);
        Officer GetOfficerByEmail(String email);
    }
}
