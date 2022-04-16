using Data;
using Data.DTO;
using Services;
using Students.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class AuthorRepo : IAuthor
    {
        private readonly StudentDbContext _dp;

        //constructor
        public AuthorRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        // 1 - delete 
        public void Delete(int? id)
        {
            Author author = _dp.Authors.Find(id);
            _dp.Authors.Remove(author);
            _dp.SaveChanges();
        }

        // 2 - get an author
        public Author GetAuthor(int? Id)
        {
            Author author = _dp.Authors.Find(Id);
            return author;
        }

        public List<AuthorBook> GetAuthorBook(int authorId)
        {
            var books = _dp.AuthorBookRelation.Where(b => b.AuthorId == authorId).ToList();

            return books;
        }

        public List<AuthorBook> GetAuthorBooks(int authorId)
        {
            throw new NotImplementedException();
        }

        // 3 - get all authors
        public IQueryable<Author> GetAuthors()
        {
            return _dp.Authors;
        }

        public List<AuthorBook> GetBookAuthors(int bookId)
        {
            var books = _dp.AuthorBookRelation.Where(b => b.BookId == bookId).ToList();

            return books;
        }

        // 4 - the number of rows
        public int GetLength()
        {
            return _dp.Authors.Count();
        }

        // 5 - add and update
        public void Save(Author author)
        {
            if(author.Id == 0)
            {
                _dp.Authors.Add(author);
                _dp.SaveChanges();
            }else
            {
                Author _entity = _dp.Authors.Find(author.Id);
                _entity.AuthorName = author.AuthorName;

                _dp.SaveChanges();
            }
        }


    }
}
