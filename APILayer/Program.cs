
using Microsoft.EntityFrameworkCore;
using DBAccessLayer.DBAccess;
using DBAccessLayer;
using LogicLayer.DBLogic;
using LogicLayer.APILogic;
using Validations.RegexChecker;
using Validations.UserCreationValidation;
using Validations;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using LogicLayer.CookieToken;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection String
builder.Services.AddDbContext<DataAccess>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DbCnnString"));
});

//DI
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IDataHandler,  DataHandler>();
builder.Services.AddTransient<IDBAccessLogic, DBAccessLogic>();
builder.Services.AddTransient<IAPILogicHandlers, APILogicHandlers>();
builder.Services.AddTransient<ILoginValidationHandler, LoginValidationHandler>();
builder.Services.AddTransient<IUserCreationValidationHandler, UserCreationValidationHandler>();
builder.Services.AddTransient<ICookieTokenLogic,  CookieTokenLogic>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Name = "X-Api-Key",
		Type = SecuritySchemeType.ApiKey,
		Description = "Input Api Key Here"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "ApiKey"
				}
			},
			Array.Empty<string>()
		}
	});
}

);

builder.Services.AddCors(options => options.AddDefaultPolicy(
	builder => builder.AllowCredentials().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
