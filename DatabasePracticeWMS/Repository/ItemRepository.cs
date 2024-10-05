using Dapper;
using DatabasePracticeWMS.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DatabasePracticeWMS.DTO;

namespace DatabasePracticeWMS.Repository
{
    public class ItemRepository : IItemRepository
    {

        private readonly IConfiguration _configuration;

        public ItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<IEnumerable<GetItemDetails>> GetItemDetails()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var items = await sqlConnection.QueryAsync<GetItemDetails>("spGetItemDetails",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return items;
        }

        public async Task InsertItem(InsertItemDTO item)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters(item);
            var items = await sqlConnection.ExecuteAsync("InsertProduct", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        }

        public async Task<IEnumerable<Merchant>> GetMerchant()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            string query = "Select Id,Name from Merchant";
            var merchantlist = await sqlConnection.QueryAsync<Merchant>(query);
            return merchantlist;

        }

        public async Task<IEnumerable<EditItemDTO>> GetItemBySKU(long sku)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters();
            parameters.Add("@SKU", sku);
            var items = await sqlConnection.QueryAsync<EditItemDTO>("spGetItemBySKU", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return items;
        }


        public async Task UpdateItem(InsertItemDTO model)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters(model);
            parameters.Add("@Id",model.SKU);
            var items = await sqlConnection.ExecuteAsync("spUpdateItem", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        //public async Task<IEnumerable<EditItemDTO>> GetAllItemDetails(Guid rowGuid)
        //{
        //    var connection = _configuration.GetConnectionString("DefaultConnection");
        //    SqlConnection sqlConnection = new SqlConnection(connection);
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@SKU", sku);
        //    var items = await sqlConnection.QueryAsync<EditItemDTO>("spGetItemBySKU", parameters,
        //    commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        //    return items;
        //}
    }
}
