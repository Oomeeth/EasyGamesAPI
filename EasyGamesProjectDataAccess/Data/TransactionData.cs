using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyGamesProjectDataAccess.DatabaseAccess;
using EasyGamesProjectDataAccess.Models;

namespace EasyGamesProjectDataAccess.Data;

public class TransactionData : ITransactionData
{
    private readonly IDataAccess? _dataAccess;

    public TransactionData(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public Task<IEnumerable<TransactionTypeModel>> GetTransactionsTypes()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.LoadData<TransactionTypeModel, dynamic>("Transaction_GetTransactionType", new { });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public Task<IEnumerable<TransactionModel>> GetTransactions(int clientID)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.LoadData<TransactionModel, dynamic>("Transaction_GetAllClient", new { ClientID = clientID });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public Task UpdateClientBalance(double clientTransactionAmount, int clientID)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.SaveData(
            "Client_UpdateBalance", new { UpdatedAmount = clientTransactionAmount, ClientID = clientID });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public Task CreateTransaction(TransactionModel transactionModel)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.SaveData(
            "Transaction_Insert", new { transactionModel.Amount, transactionModel.TransactionTypeID, transactionModel.ClientID, transactionModel.Comment });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public Task UpdateCommentTransaction(int transactionID, string updatedComment)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return _dataAccess.SaveData(
            "Transaction_UpdateComments", new { TransactionID = transactionID, Comment = updatedComment });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
