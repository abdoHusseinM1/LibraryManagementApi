using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBook
    {
        public void Delete(int? id);
        public int SaveBook(Book book);
        public Book GetBook(int? id);
        public int GetLength();
        public SubCategory GetSubCategory(int bookId);
        public List<Book> GetAllBooks();
        public List<Book> GetBooksFromSubCategory(int subCategoryId);
    }
}
