using Microsoft.Azure.Cosmos;
using CosmosDbService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton((s) => { return new CosmosClient("AccountEndpoint=https://scrapdata.documents.azure.com:443/;AccountKey=VMxs6A0kuEzFTgG1CjNMTHXzFByVqHrAjLE5w4ucWyGBW87bPVZ6Jt5QPdrsk7ig6Zk5WmshAka47FtaXqJrOw==;"); });
builder.Services.AddScoped<ICosmosApiClient,CosmosApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
