using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthor
    {
        Author GetAuthor(int? Id);

        IQueryable<Author> GetAuthors();

        void Save(Author author);
        void Delete(int? id);
        int GetLength();

        public List<AuthorBook> GetAuthorBooks(int authorId);

        public List<AuthorBook> GetBookAuthors(int bookId);
  }
}
