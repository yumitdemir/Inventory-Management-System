using Inventory_Management_System.Models;

namespace Inventory_Management_System.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupliers();
        
        Task<Supplier> GetDataByIDAsync(int id);




        bool Add(Supplier supplier);
        bool Update(Supplier supplier);
        bool Delete(Supplier supplier);
        bool Save();
    }
}
