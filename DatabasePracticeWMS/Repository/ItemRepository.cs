using Dapper;
using DatabasePracticeWMS.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DatabasePracticeWMS.Repository
{
    public class ItemRepository
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
            var items = await sqlConnection.QueryAsync<GetItemDetails>("spGetUserByEmail",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return items;
        }
    }
}
