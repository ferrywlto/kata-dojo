var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/add", (AddModel model) =>
{
    var service = new AddService();
    var result = service.Add(model.num1, model.num2);

    return result;
});

app.Run();

record AddModel(int num1, int num2);
