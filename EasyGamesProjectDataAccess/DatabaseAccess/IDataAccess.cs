namespace EasyGamesProjectDataAccess.DatabaseAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionData = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionData = "Default");
    }
}