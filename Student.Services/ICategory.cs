using Data;
using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategory
    {
        Category GetCategory(int? Id);
        List<Category> GetCategories();
        void Save(Category Category);
        void Delete(int? Id);
        int GetLength();
        int GetBooksLength(int Id);
    }
}
