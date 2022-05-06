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
        

        //delete a category
        public void Delete(int? Id)
        {
            Category cat = _dp.Categories.Find(Id);
            if(cat != null)
            {
                _dp.Remove(cat);
                _dp.SaveChanges();
            }
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
            int length = _dp.Categories.Count();
            return length;
        }

        //get all
        public List<Category> GetCategories()
        {
            List<Category> categories = _dp.Categories.ToList();
            return categories;
        }

        public int GetBooksLength(int Id)
        {
            List<SubCategory> subCategories = _dp.SubCategories.Where(s => s.MainCategoryId == Id).ToList();
            var subsId = new List<int>();
            for(int i = 0; i<subCategories.Count; i++)
            {
                subsId.Add(subCategories[i].MainCategoryId);
            }
            var books = _dp.Books.Where(b => subsId.Contains(b.SubCategoryId)).ToList().Count;
            return books;
        }

       
    }
}
