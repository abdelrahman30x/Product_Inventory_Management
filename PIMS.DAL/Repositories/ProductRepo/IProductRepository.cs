using PIMS.DAL.Models.Product;
using System.Linq;

namespace PIMS.DAL.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll(bool withTracking = false);
        Product GetByID(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
