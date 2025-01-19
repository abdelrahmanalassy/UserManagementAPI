using UserManagementAPI.Services;
using UserManagementAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Services to Program.cs
builder.Services.AddHttpClient<RandomUserService>(Client =>
{
    Client.BaseAddress = new Uri("https://randomuser.me/");
});
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

//Configure the HTTP Request pipline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();