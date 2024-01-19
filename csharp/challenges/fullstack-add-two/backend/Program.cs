
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Builder;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});
var app = builder.Build();

app.MapPost("/add", async (AddModel model) =>
{
    var service = new AddService();
    var result = service.Add(model.num1, model.num2);

    var client = new MongoClient("mongodb://database:27017");
    var database = client.GetDatabase("LiveCodingChallenege");
    var collection = database.GetCollection<AddModelWithResult>("AddResult");
    await collection.InsertOneAsync(new AddModelWithResult(model.num1, model.num2, result));

    return result;
});
app.UseCors();

app.Run();

record AddModel(int num1, int num2);
record AddModelWithResult(int num1, int num2, int result);