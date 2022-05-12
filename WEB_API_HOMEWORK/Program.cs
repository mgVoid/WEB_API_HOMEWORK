using WEB_API_HOMEWORK.Interfaces;
using WEB_API_HOMEWORK.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddSingleton<IPerformanceService, PerformanceService>();
builder.Services.AddSingleton<ISortingService, SortingService>();
builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore();



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

app.Run();
