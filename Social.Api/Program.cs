using Microsoft.EntityFrameworkCore;
using Social.Api.Database;
using Social.Api.Repository;
using Social.Api.Services;

var builder = WebApplication.CreateBuilder(args);

const string CorsOrigins = "_corsOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsOrigins,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var server = builder.Configuration.GetValue(typeof(string), "DbConnection:Server").ToString();
var db = builder.Configuration.GetValue(typeof(string), "DbConnection:Database").ToString();
var user = builder.Configuration.GetValue(typeof(string), "DbConnection:User").ToString();
var pass = builder.Configuration.GetValue(typeof(string), "DbConnection:Password").ToString();
var connectionString = ConnectionStringCreator.BuildConnectionString(server, db, user, pass);
builder.Services.AddDbContext<SanSocialContext>(options =>
{
    options.UseSqlServer(connectionString,
        assembly => assembly.MigrationsAssembly(typeof(SanSocialContext).Assembly.FullName));
});


builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISocialRepository, SocialRepository>();
builder.Services.AddScoped<ISocialService, SocialService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(CorsOrigins);
app.MapControllers();
app.Run();
