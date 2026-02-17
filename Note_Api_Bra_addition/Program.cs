using BussinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.LoginPath = "/login";
//        options.AccessDeniedPath = "/login";
//    }


builder.Services.AddAuthorization();
builder.Services.AddDataAccess();
builder.Services.AddBusinessLogic();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");



app.UseStaticFiles(); // /swagger/index.html
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
