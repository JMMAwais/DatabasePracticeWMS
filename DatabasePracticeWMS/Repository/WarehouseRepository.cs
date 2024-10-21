using DatabasePracticeWMS.Models;
using System.Data.SqlClient;
using System.Data;
using DatabasePracticeWMS.Models.Warehouse;
using Dapper;
using System.Reflection;
using System;

namespace DatabasePracticeWMS.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IConfiguration _configuration;

        public WarehouseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetWarehouseDetail>> GetWarehouseDetails()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var warehouse = await sqlConnection.QueryAsync<GetWarehouseDetail>("spGetWarehouseDetail",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return warehouse;
        }

        public async Task<IEnumerable<Cities>> GetCities()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            string query = "Select Id,CityName from Cites";
            var Citylist = await sqlConnection.QueryAsync<Cities>(query);
            return Citylist;
        }

        public async Task AddWarehouseWithCity(AddWarehouse warehouse)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters();
            parameters.Add("@WarehouseName", warehouse.Name, DbType.String);
            parameters.Add("@CityId", warehouse.CityId, DbType.Int64);

            await sqlConnection.ExecuteAsync("spAddWarehouseWithCity", parameters,
           commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }


        public async Task<EditWarehouse> GetWarehouseByGuid(Guid guid)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters();
            parameters.Add("@RowGuid", guid, DbType.Guid);
            var warehouses = await sqlConnection.QueryAsync<EditWarehouse>("SpGetWarehousByGuid", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return warehouses.FirstOrDefault();
        }

        public async Task UpdateWarehouse(EditWarehouse warehouse)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters();
            parameters.Add("@WarehouseId", warehouse.Id, DbType.Int64);
            parameters.Add("@WarehouseName", warehouse.Name, DbType.String);
            parameters.Add("@CityId", warehouse.CityId, DbType.Int64);
            await sqlConnection.ExecuteAsync("SpUpdateWarehouse", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        }

        public async Task DeleteWarehouse(int Id)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            string query = "Delete from Warehouse where Id=@Id";
            var parameters = new DynamicParameters();
            await sqlConnection.ExecuteAsync(query, new { Id = Id });

        }
    }
}
