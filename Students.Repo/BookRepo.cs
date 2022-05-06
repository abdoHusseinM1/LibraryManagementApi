using Data;
using Services;
using Students.Repo;
using System.Collections.Generic;
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
        public List<Book> GetAllBooks()
        {
            var books = _dp.Books.ToList();

            return books;
        }

        // get book with id
        public Book GetBook(int? id)
        {
            var book = _dp.Books.Find(id);
            if (book == null)
            {
                return null;
            }

            return book;
        }

        // get all books from sub category
        public List<Book> GetBooksFromSubCategory(int subCategoryId)
        {
            var books = _dp.Books.Where(s => s.SubCategoryId == subCategoryId).ToList();

            return books;
        }

        // get length
        public int GetLength()
        {
            return _dp.Books.Count();
        }

        //get book sub-category 
        public SubCategory GetSubCategory(int bookId)
        {
            var book = _dp.Books.Find(bookId);
            if (book != null)
                return _dp.SubCategories.Find(book.SubCategoryId);

            return null;
        }

        //add and update book
        public int SaveBook(Book book)
        {
            var books = _dp.Books.Where(b => book.Title.ToUpper() == b.Title.ToUpper()).ToList();
            if (books.Count < 1)
            {
                _dp.Add(book);
                _dp.SaveChanges();
                return 0;
            }
            return -1;
        }

        public int EditBook(Book book)
        {
            var books = _dp.Books.Where(b => b.Title.ToUpper() == book.Title.ToUpper() &&
            b.PublishedYear == book.PublishedYear && b.SubCategoryId == book.SubCategoryId).ToList();

            if (books.Count > 0)
            {
                return -1;
            }
            _dp.Books.Find(book.Id).Title = book.Title;
            _dp.Books.Find(book.Id).PublishedYear = book.PublishedYear;
            _dp.Books.Find(book.Id).SubCategoryId = book.SubCategoryId;
            _dp.Books.Find(book.Id).AvailableQuantity = book.AvailableQuantity;
            _dp.SaveChanges();
            return 0;
        }
    }
}
