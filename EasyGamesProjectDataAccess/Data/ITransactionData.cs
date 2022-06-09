using EasyGamesProjectDataAccess.Models;

namespace EasyGamesProjectDataAccess.Data
{
    public interface ITransactionData
    {
        public Task<IEnumerable<TransactionTypeModel>> GetTransactionsTypes();
        public Task CreateTransaction(TransactionModel transactionModel);
        Task<IEnumerable<TransactionModel>> GetTransactions(int clientID);
        public Task UpdateCommentTransaction(int transactionID, string updatedComment);
        public Task UpdateClientBalance(double clientTransaction, int clientID);
    }
}