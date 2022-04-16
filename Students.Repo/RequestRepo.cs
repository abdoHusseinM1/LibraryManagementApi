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
    public class RequestRepo : IRequest
    {

        private readonly StudentDbContext _dp;

        public RequestRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        
        public void ChangeRequesStatus(int? Id ,string NewStatus)
        {
            _dp.Requests.Find(Id).Status = NewStatus;
            _dp.SaveChanges();
        }

        // Delete Request
        public void DeleteRequest(int? Id)
        {
            _dp.Requests.Remove(_dp.Requests.Find(Id));
            _dp.SaveChanges();
        }

        public int GetLength()
        {
            List<Request> list = _dp.Requests.ToList();
            return list.Count;
        }

        public IQueryable GetRequests()
        {
            return _dp.Requests;
        }

        public List<Request> GetRequestsByStudentNationalId(string NationalId)
        {
            int Id = _dp.Students.Where(s => s.NationalId == NationalId).FirstOrDefault().Id;
            List<Request> list = _dp.Requests.Where(r => r.Id == Id).ToList();
            return list;
        }

        public string Save(Request request)
        {
            if(_dp.Books.Find(request.BookId).AvailableQuantity <= 0)
            {
                return "No Available Quantity";
            }else if (request.Id == 0)
            {
                _dp.Requests.Add(request);

                _dp.SaveChanges();
                return "Saved";
            }else
            {
                return "Error";
            }
        }
    }
}
