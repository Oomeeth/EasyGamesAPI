using EasyGamesProjectDataAccess.DatabaseAccess;
using EasyGamesProjectDataAccess.Models;

namespace EasyGamesProjectDataAccess.Data;

public class ClientData : IClientData
{
    private readonly IDataAccess? _dataAccess;

    public ClientData(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<ClientModel>> GetClients()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.LoadData<ClientModel, dynamic>("Client_GetAll", new { });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public async Task<ClientModel?> GetClient(int id)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var result = await _dataAccess.LoadData<ClientModel, dynamic>("Client_Get", new { ClientID = id });
        return result.FirstOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public Task CreateClient(ClientModel client)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.SaveData("Client_Insert", new { client.FirstName, client.Surname, client.ClientBalance });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
