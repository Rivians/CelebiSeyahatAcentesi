using CelebiSeyahat.Application.Extensions;
using CelebiSeyahat.Infrastructure.Extensions;
using CelebiSeyahat.Persistence.Context;
using CelebiSeyahat.Persistence.Extensions;
using CelebiSeyahat.Persistence.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<CelebiSeyehatDbContext>(options => options.UseSqlServer(connectionString));

/*builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));*/ // ConnectionStrings bölümündeki deðerleri, DatabaseSettings sýnýfýnýn özelliklerine eþler.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);


builder.Services.AddControllers();
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
