using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.DependecyResolvers.Autofac;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Authentication;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Core.Utilities.IoC;
using Core.Extensions;
using Core.DependecyResolvers;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			// Set up Autofac
			var containerBuilder = new ContainerBuilder();
			containerBuilder.Populate(builder.Services);

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
					};
				});
			builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule()});
			builder.Host
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>(cb => { cb.RegisterModule(new AutofacBusinessModule()); });
			var app = builder.Build();
			// Use the Autofac container as the service provider
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseAuthentication();

			app.MapControllers();

			app.Run();
		}
	}
}