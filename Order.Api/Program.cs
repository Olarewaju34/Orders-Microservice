using FluentValidation.AspNetCore;
using Order.Api.MiddleWare;
using Order.BusinessLogic;
using Order.BusinessLogic.HttpClients;
using Order.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccessLayerDI(builder.Configuration);
builder.Services.AddBusinessLogicDI(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

});
builder.Services.AddHttpClient<UserMicroServiceClient>(client =>
{
    client.BaseAddress = new Uri($"http://{builder.Configuration["UsersMicroserviceName"]}:{builder.Configuration["UsersMicroservicePort"]}"); 
});

var app = builder.Build();

app.UseExceptionHandlingMiddlewares();
app.UseRouting();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
