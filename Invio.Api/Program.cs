using Invio.Application.Configurations;
using Invio.Domain.Entities;
using Invio.Infrastructure.Configurations;
using Invio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<Usuario, IdentityRole<Guid>>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;

    options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();



//este código abaixo trouxe erro ao realizar a migration, esta comentado para fins de documentação
//builder.Services.AddIdentityCore<Usuario>(options =>
//{
//    options.Password.RequiredLength = 6;
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;

//    options.SignIn.RequireConfirmedEmail = false;
//})
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddRoles<IdentityRole<Guid>>()
//    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
//    .AddSignInManager<SignInManager<Usuario>>()
//    .AddUserManager<UserManager<Usuario>>()
//    .AddDefaultTokenProviders();


builder.Services
    .RegisterRepository()
    .RegisterApplication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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
