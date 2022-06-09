using EasyGamesProjectDataAccess.Data;
using EasyGamesProjectDataAccess.DatabaseAccess;
using EasyGamesProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSingleton<IDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<IClientData, ClientData>();
builder.Services.AddSingleton<ITransactionData, TransactionData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureAPI();

app.MapControllers();

app.Run();
