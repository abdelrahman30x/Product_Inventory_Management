using PIMS.DAL.Models.Category;
using System.Linq;

namespace PIMS.DAL.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll(bool withTracking = false);
        Category GetByID(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
