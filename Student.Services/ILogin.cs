using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos_Interfaces
{
    public interface ILogin
    {
        int LoginStudent(LoginUser user);
        int LoginOfficer(LoginUser user);
    }
}
