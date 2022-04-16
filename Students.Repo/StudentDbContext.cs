using Data;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repo
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<AuthorBook> AuthorBookRelation { get; set; }

    }
}
