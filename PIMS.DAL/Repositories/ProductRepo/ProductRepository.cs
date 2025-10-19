using Microsoft.EntityFrameworkCore;
using PIMS.Contexts;
using PIMS.DAL.Models.Product;
using System.Linq;

namespace PIMS.DAL.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbcontext _context;

        public ProductRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _context.Products.Include(p => p.Category);
            else
                return _context.Products.Include(p => p.Category).AsNoTracking();
        }

        public Product GetByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = _context.Products.Find(id);
            if (existing != null)
            {
                _context.Products.Remove(existing);
                _context.SaveChanges();
            }
        }
    }
}
