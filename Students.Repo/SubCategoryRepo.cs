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
    public class SubCategoryRepo : ISubCategory
    {
        private readonly StudentDbContext _dp;

        public SubCategoryRepo(StudentDbContext dp)
        {
            _dp = dp;
        }

        public void ChangeMainCategory(int? SubCategoryId, int NewMainCategoryId)
        {
            _dp.SubCategories.Find(SubCategoryId).MainCategoryId = NewMainCategoryId;
            _dp.SaveChanges();
        }

        public void Delete(int? id)
        {
            _dp.SubCategories.Remove(_dp.SubCategories.Find(id));
            _dp.SaveChanges();
        }

        public int getlength(int? MainCategoryId)
        {
            List<SubCategory> s = _dp.SubCategories.Where(s => s.MainCategoryId == MainCategoryId).ToList();
            return s.Count;
        }

        public IQueryable<SubCategory> GetSubCategories(int? MainCategoryId)
        {
            IQueryable<SubCategory> s = _dp.SubCategories.Where(s => s.MainCategoryId == MainCategoryId);
            return s;
        }

        public SubCategory GetSubCatgory(int? id)
        {
            return _dp.SubCategories.Find(id);
        }

        public void Save(SubCategory subCategory)
        {
            if(subCategory.Id == 0)
            {
                _dp.Add(subCategory);
                _dp.SaveChanges();
            }else
            {
                _dp.SubCategories.Find(subCategory.Id).Name = subCategory.Name;
                _dp.SubCategories.Find(subCategory.Id).MainCategoryId = subCategory.MainCategoryId;

                _dp.SaveChanges();
            }
        }
    }
}
