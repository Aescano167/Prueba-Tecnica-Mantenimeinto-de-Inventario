using InventoryApp.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var setup = new AppSetup(builder.Configuration);
setup.ConfigureCors(builder.Services);
setup.AddSwagger(builder.Services);
setup.AddDbContext(builder.Services);
setup.ConfigureServices(builder.Services);
setup.ConfigureRepository(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("InventoryPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
