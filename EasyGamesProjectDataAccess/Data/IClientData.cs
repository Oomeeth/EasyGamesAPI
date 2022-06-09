using EasyGamesProjectDataAccess.Models;

namespace EasyGamesProjectDataAccess.Data
{
    public interface IClientData
    {
        Task CreateClient(ClientModel client);
        Task<IEnumerable<ClientModel>> GetClients();
        Task<ClientModel> GetClient(int clientID);
    }
}