using DatabasePracticeWMS.Models.Warehouse;
using System.Threading.Tasks;

namespace DatabasePracticeWMS.Repository
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<GetWarehouseDetail>> GetWarehouseDetails();
        Task<IEnumerable<Cities>> GetCities();
        Task AddWarehouseWithCity(AddWarehouse warehouse);
        Task<EditWarehouse> GetWarehouseByGuid(Guid guid);
        Task UpdateWarehouse(EditWarehouse warehouse);
        Task DeleteWarehouse(int Id);

    }
}
