using CRUDApi.Context;
using CRUDApi.Interface;
using CRUDApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFromAll",
        builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .WithMethods("GET", "POST", "PUT", "DELETE");
        });
});
builder.Services.AddDbContext<CRUDContext>(options =>
{
    options.UseInMemoryDatabase(nameof(CRUDContext));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowFromAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
