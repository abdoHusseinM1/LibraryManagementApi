using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISubCategory
    {
        SubCategory GetSubCatgory(int? id);
        IQueryable<SubCategory> GetSubCategories(int? MainCategoryId);
        void Save(SubCategory subCategory);
        void Delete(int? id);
        void ChangeMainCategory(int? SubCategoryId, int NewMainCategoryId);
        int getlength(int? MainCategoryId);
    }
}
