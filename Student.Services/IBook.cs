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
        public void SaveBook(Book book);
        public int GetLength();
        public int GetSubCategoryId(int bookId);
        public IQueryable GetAllBooks();
        public IQueryable GetBooksFromSubCategory(int subCategoryId);
    }
}
