using Core_Providentia_vitae.Data;
using Microsoft.EntityFrameworkCore;

// Area de Services
using Core_Providentia_vitae.Services;
using Core_Providentia_vitae.Services.RH;

// PROFILE DE MAPEAMENTO
using Core_Providentia_vitae.Profiles;
using Core_Providentia_vitae.Services.Admin.Modules;
using Core_Providentia_vitae.Data.Admin;
using Core_Providentia_vitae.Data.RH;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddDbContextFactory<MssqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLSERVERCON")));

// ✅ MYSQL - Sistema principal 
builder.Services.AddDbContext<MysqlContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Mysql"),
        new MySqlServerVersion(new Version(8, 0, 33))
    ));

// builder.Services.AddDbContext<AdminContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("Mysql"),
//     new MySqlServerVersion(new Version(8, 0, 33))
//     ));

builder.Services.AddDbContext<RhContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("Mysql"),
new MySqlServerVersion(new Version(8, 0, 33))
));

builder.Services.AddScoped<FuncionariosService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RhServices>();
builder.Services.AddScoped<ModulesService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    try
    {
        var sqlServerContext = scope.ServiceProvider.GetRequiredService<MssqlContext>();
        await sqlServerContext.Database.CanConnectAsync();
        Console.WriteLine("✅ Conexão com SQL Server bem-sucedida");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Falha na conexão com SQL Server: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
