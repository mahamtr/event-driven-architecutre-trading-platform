using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB configuration
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
