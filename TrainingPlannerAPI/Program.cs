using MongoDB.Driver;
using MongoDB.Bson;
using vbsessionplan.DAO;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["MongoDB:ConnectionString"];
var settings = MongoClientSettings.FromConnectionString(connectionString);

settings.ServerApi = new ServerApi(ServerApiVersion.V1);

var client = new MongoClient(settings);

try
{
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}



builder.Services.AddSingleton<IExercisesDAO, ExercisesDAO>(serviceProvider => new ExercisesDAO(client));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
