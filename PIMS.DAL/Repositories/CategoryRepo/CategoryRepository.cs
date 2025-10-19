using Microsoft.EntityFrameworkCore;
using PIMS.Contexts;
using PIMS.DAL.Models.Category;
using System.Linq;

namespace PIMS.DAL.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbcontext _context;

        public CategoryRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _context.Categories;
            else
                return _context.Categories.AsNoTracking();
        }

        public Category GetByID(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
