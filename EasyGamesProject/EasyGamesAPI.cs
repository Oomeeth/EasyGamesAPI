using EasyGamesProjectDataAccess.Data;
using EasyGamesProjectDataAccess.Models;

namespace EasyGamesProject
{
    public static class EasyGamesAPI
    {
        public static void ConfigureAPI(this WebApplication app)
        {
            app.MapGet("/clients", GetClients);
            app.MapGet("/client/{clientID}", GetClient);
            app.MapPost("/clients", CreateClient);
            app.MapGet("/transactions/{clientID}", GetTransactions);
            app.MapGet("/transactiontypes", GetTransactionTypes);
            app.MapPost("/transactions", CreateTransaction);
            app.MapPost("/transactions/{transactionID}/{updatedcomment}", UpdateCommentTransaction);
        }

        public static async Task<IResult> GetClients(IClientData clients)
        {
            try
            {
                return Results.Ok(await clients.GetClients());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetClient(IClientData clients, int clientID)
        {
            try
            {
                return Results.Ok(await clients.GetClient(clientID));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetTransactionTypes(ITransactionData transactionData)
        {
            try
            {
                return Results.Ok(await transactionData.GetTransactionsTypes());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> CreateClient(ClientModel clientModel, IClientData client)
        {
            try
            {
                await client.CreateClient(clientModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetTransactions(ITransactionData transactionData, int clientID)
        {
            try
            {
                return Results.Ok(await transactionData.GetTransactions(clientID));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> CreateTransaction(TransactionModel transactionModel, ITransactionData transactionData)
        {
            try
            {
                await transactionData.CreateTransaction(transactionModel);
                await transactionData.UpdateClientBalance(transactionModel.Amount, transactionModel.ClientID);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateCommentTransaction(ITransactionData transactionData, int transactionID, string updatedComment)
        {
            try
            {
                await transactionData.UpdateCommentTransaction(transactionID, updatedComment);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
