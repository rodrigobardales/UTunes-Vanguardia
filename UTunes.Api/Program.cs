﻿using Microsoft.EntityFrameworkCore;
using UTunes.Core;
using UTunes.Core.AlbumManager;
using UTunes.Core.SongManager;
using UTunes.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var allowAllOriginsPolicy = "_allowAllOriginsPolicy";


// Add services to the container.

builder.Services.AddDbContext<UTunesContext>(options => options.UseSqlite("DataSource=UTunes.db"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOriginsPolicy,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
builder.Services.AddControllers();
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

app.UseCors(allowAllOriginsPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

