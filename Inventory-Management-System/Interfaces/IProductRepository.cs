using Inventory_Management_System.Models;

namespace Inventory_Management_System.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllDataAsync();

        Task<Product> GetDataByIDAsync(int id);




        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();

    }
}
