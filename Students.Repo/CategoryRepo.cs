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
    public class CategoryRepo : ICategory
    {
        private readonly StudentDbContext _dp;

        //constructor
        public CategoryRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        //get all categories
        

        //delete a category
        public void Delete(int? Id)
        {
            Category cat = _dp.Categories.Find(Id);
            _dp.Remove(cat);
            _dp.SaveChanges();
        }

        //get a category
        public Category GetCategory(int? Id)
        {
            Category category = _dp.Categories.Find(Id);
            return category;
        }

        //add or update a category
        public void Save(Category Category)
        {
            if(Category.Id == 0)
            {
                _dp.Categories.Add(Category);
                _dp.SaveChanges();
            }else
            {
                Category _entity = _dp.Categories.Find(Category.Id);
                _entity.CategoryName = Category.CategoryName;

                _dp.SaveChanges();
            }
        }

        //get length
        public int GetLength()
        {
            IQueryable<Category> categories = _dp.Categories;
            return categories.Count();
        }

        public IQueryable<Category> GetCategories()
        {
            return _dp.Categories;
        }
    }
}
