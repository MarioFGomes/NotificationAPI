using Notification.API.Filter;
using Notification.Aplication.Commands.NotificationTypes.CreateNotificationTypes;
using Notification.Aplication.Service.Automapper;
using Notification.Infrastructure.DataAcess;
using Notification.Infrastructure.DataAcess.Migrations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository(builder.Configuration);


builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(config => {
    config.AddProfile(new AutoMapperConfiguration());
}).CreateMapper());


builder.Services.AddMediatR(s => s.RegisterServicesFromAssemblies(typeof(CreateNotificationsTypesCommand).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrationsDataBase();

app.Run();




public partial class Program { }