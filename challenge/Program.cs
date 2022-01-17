using challenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ITranslationService, TranslationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// For this challenge we leave swagger in prod
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecureSwagger v1"));
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

