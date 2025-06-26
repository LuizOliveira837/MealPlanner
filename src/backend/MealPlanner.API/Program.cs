using MealPlanner.API.Filter;
using MealPlanner.Application;
using MealPlanner.Persistence;
using MealPlanner.Persistence.Extensions;
using MealPlanner.Persistence.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(opt => opt.Filters.Add(typeof(MealPlannerExceptionFilter)));
builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
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

app.UseAuthorization();

app.MapControllers();

EnsureDatabase(app.Services);

app.Run();


void EnsureDatabase(IServiceProvider provider)
{
    var scope = provider.CreateScope().ServiceProvider;
    CreateMigration.EnsureDatabase(app.Configuration.GetConnectionStringMealPlanner());
    CreateMigration.UpMigrations(scope);
}
