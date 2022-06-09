using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace EasyGamesProjectDataAccess.DatabaseAccess;

public class SQLDataAccess : IDataAccess
{
    private readonly IConfiguration _config;
    public SQLDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionData = "Default")
    {
        //using properly shuts down the connection
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionData));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionData = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionData));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
