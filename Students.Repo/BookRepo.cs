using Data;
using Services;
using Students.Repo;
using System.Linq;

namespace Repos
{
    public class BookRepo : IBook
    {
        private readonly StudentDbContext _dp;

        public BookRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        // delete
        public void Delete(int? id)
        {
            var book = _dp.Books.Find(id);

            if (book == null)
                return;
        
            _dp.Remove(book);
            _dp.SaveChanges();

        }

        // get all books
        public IQueryable GetAllBooks()
        {
            IQueryable books = _dp.Books;
            return books;
        }

        // get all books from sub category
        public IQueryable GetBooksFromSubCategory(int subCategoryId)
        {
            IQueryable books = _dp.Books.Where(s => s.SubCategoryId == subCategoryId);
            return books;
        }

        // get length
        public int GetLength()
        {
            return _dp.Books.Count();
        }

        //get book sub-category id
        public int GetSubCategoryId(int bookId)
        {
            if(_dp.Books.Find(bookId) == null)
                return 0;
           
            return _dp.Books.Find(bookId).SubCategoryId;                
        }

        //add and update book
        public void SaveBook(Book book)
        {
            if(book.Id == 0)
            {
                _dp.Add(book);
                _dp.SaveChanges();
            }else
            {
                _dp.Books.Find(book.Id).title = book.title;
                _dp.Books.Find(book.Id).PublishedYear = book.PublishedYear;
                _dp.Books.Find(book.Id).SubCategoryId = book.SubCategoryId;
                _dp.Books.Find(book.Id).AvailableQuantity = book.AvailableQuantity;

                _dp.SaveChanges();
            }
        }
    }
}
