using DatabasePracticeWMS.Models;
using System.Data.SqlClient;
using System.Data;
using DatabasePracticeWMS.Models.Storage;
using Dapper;

namespace DatabasePracticeWMS.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IConfiguration _configuration;

        public StorageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<StorageDetails>> StorageDetails()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var storage = await sqlConnection.QueryAsync<StorageDetails>("spStorageDetails",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return storage;
        }

        public async Task<IEnumerable<StockLocation>> GetStockLocations( int Id)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);
            var stock = await sqlConnection.QueryAsync<StockLocation>("spGetStorageLocation",
            parameters,commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return stock;
        }


    }
}
