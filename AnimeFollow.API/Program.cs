using AnimeFollowMVC.DAL.SQLServer.Depots;
using AnimeFollowMVC.Services.DepotInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDepotUsers, UserDepot_SQLServer>();
builder.Services.AddScoped<IDepotAnime, AnimeDepot_SQLServer>();
builder.Services.AddScoped<IDepotAnimeUserStatus, AnimeUserStatusDepot_SQLServer>();

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
