using DatabasePracticeWMS.Models;
using System.Data.SqlClient;
using System.Data;
using DatabasePracticeWMS.Models.Storage;
using Dapper;

namespace DatabasePracticeWMS.Repository
{
    public class StorageRepository:IStorageRepository
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
    }
}
