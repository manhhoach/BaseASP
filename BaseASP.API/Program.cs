using Autofac;
using Autofac.Extensions.DependencyInjection;
using BaseASP.API.Common;
using BaseASP.API.Modules;
using BaseASP.Model;
using BaseASP.Service.JwtService;
using BaseASP.Service.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthMiddleware>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new EFModule());
    container.RegisterModule(new RepositoryModule());
    container.RegisterModule(new ServiceModule());
    container.RegisterModule(new AutoMapperModule());
    container.RegisterModule(new RedisModule(builder.Configuration));
    container.RegisterModule(new ElasticsearchModule());
    container.RegisterModule(new JwtModule());
});


var app = builder.Build();

app.Use(async (context, next) =>
{
    await next.Invoke();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

