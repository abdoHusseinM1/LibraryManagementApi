using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRequest
    {
        public void DeleteRequest(int? Id);
        public string Save(Request request);
        public int GetLength();
        public IQueryable GetRequests();
        public List<Request> GetRequestsByStudentNationalId(string NationalId);
        public void ChangeRequesStatus(int? Id, string NewStatus);

    }
}
