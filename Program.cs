using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using rapid_news_media_comments_api.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommentsDbContext>(opt => opt.UseInMemoryDatabase("CommentsDb"));

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Initialize Seed for In Memory Database 
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<CommentsDbContext>();
    dbcontext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom auth middleware
app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
