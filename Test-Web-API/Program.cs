using Test_Web_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Example of the injection of dependencies loC (container)
builder.Services.AddSingleton<IPeopleService, PeopleService>();

/* 
    IMPORTANT!!!
    // Available only in .NET 8 Key injections to decide which interface implementation to use
    builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
    builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService02");
    
    // In controller indicates the implementation Key (peopleService or peopleService02)
    public PeopleController([FromKeyedServices("peopleService02")]IPeopleService peopleService)
     {
            _peopleService = peopleService;
     } 
*/

// Examples of injection Types (Singleton, Scoped and Transient) 
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
