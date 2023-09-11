using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewok;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Autofac.Core;
using Core.Utilities.Security.JWT;
using System.Security.Cryptography.X509Certificates;
using TokenOptions = Core.Utilities.Security.JWT.TokenOptions;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(options =>
{
    options.RegisterModule(new AutofacBusinessModule());
});
// Add services to the container.


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();// Token Options to Token Options
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//jwt tabanl� yetkilendirme etkinle�tirmek i�in
    .AddJwtBearer(options =>//jwt yap�land�rmas�
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//veren taraf
            ValidateAudience = true,//hedef kitle
            ValidateLifetime = true,//s�resi 
            ValidIssuer = tokenOptions.Issuer,//hangi kaynak
            ValidAudience = tokenOptions.Audience,//hangi hizmet taraf�ndan kullan�lacak
            ValidateIssuerSigningKey = true,//key do�rulama
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });//dependencyResolvers ekleme


builder.Services.AddControllers();
builder.Services.AddCors();


// Di�er ayarlamalar


//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Di�er ayarlamalar

app.UseStaticFiles(); // wwwroot i�indeki dosyalara eri�imi etkinle�tirir.

app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("http://localhost:4200"));


app.UseHttpsRedirection();
app.UseAuthentication();//Kullan�c� s�yledi�i ki�i mi?
app.UseAuthorization();//yetki vs. do�rulad�ktan sonra kullan�c� hangi kaynaklara eri�ebilir do�rulamas�?

app.MapControllers();

app.Run();
