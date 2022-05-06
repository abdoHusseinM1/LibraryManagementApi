using Data;
using Services;
using Students.Data;
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

        // cancel request
        public void CancelRequest(int requestId)
        {
            Request r = _dp.Requests.Find(requestId);
            _dp.Requests.Find(requestId).Status = "Canceled" ;
            _dp.Books.Find(r.BookId).AvailableQuantity++;
            _dp.SaveChanges();
        }

        
        // Delete Request
        public void DeleteRequest(int? Id)
        {
            Request r = _dp.Requests.Find(Id);
            _dp.Books.Find(r.BookId).AvailableQuantity++;
            _dp.Requests.Remove(_dp.Requests.Find(Id));
            _dp.SaveChanges();
        }

        // get length
        public int GetLength()
        {
            List<Request> list = _dp.Requests.ToList();
            return list.Count;
        }

        // get all requests
        public List<Request> GetRequests()
        {
            return _dp.Requests.ToList();
        }

        // get by student national id
        public List<Request> GetRequestsByStudentNationalId(string NationalId)
        {
            Student student = _dp.Students.Where(s => s.NationalId == NationalId).FirstOrDefault();
            
            if (student != null)
            {
                List<Request> list = _dp.Requests.Where(r => r.StudentName == student.FullName).ToList();
                return list;
            }

            return new List<Request>();
        }

        // return book
        public void ReturnBook(int requestId)
        {
            Request r = _dp.Requests.Find(requestId);
            _dp.Requests.Find(r.Id).Status = "Book Returned";
            _dp.Books.Find(r.BookId).AvailableQuantity++;
            _dp.SaveChanges();
        }

        public string Save(Request request)
        {
            var book = _dp.Books.Find(request.BookId);
            if(book == null)
            {
                return "Null Book";
            }

            if (book.AvailableQuantity <= 0)
            {
                return "No Available Quantity";
            }else if (request.Id == 0)
            {
                request.Status = "Pending";
                request.RequestDate = DateTime.Now;
                _dp.Requests.Add(request);
                int avQ = _dp.Books.Find(request.BookId).AvailableQuantity;
                _dp.Books.Find(request.BookId).AvailableQuantity = avQ - 1;

                _dp.SaveChanges();
                return "Saved";
            }else
            {
                return "Error";
            }
        }

        public Request getRequest(int? id)
        {
            Request r = _dp.Requests.Find(id);
            return r;
        }

        public void RefreshStatus()
        {
            DateTime now = DateTime.Now;
            
            List<Request> allRequests = _dp.Requests.ToList();
            for (int i = 0; i < allRequests.Count; i++)
            {
                DateTime dateTime = allRequests[i].RequestDate;
                TimeSpan difference = now - dateTime;
                if (difference.Days >= 2 && allRequests[i].Status.ToUpper().Equals("PENDING"))
                {
                    allRequests[i].Status = "Canceled";
                    _dp.Update(allRequests[i]);
                }
            }
            _dp.SaveChanges();
        }
    }
}
