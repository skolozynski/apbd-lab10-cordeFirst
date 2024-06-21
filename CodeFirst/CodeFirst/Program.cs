using CodeFirst.Data;
using CodeFirst.Repositories;
using CodeFirst.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddControllers();
/*builder.Services.AddDbContext<ApplicationContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);*/
builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLLite"))
);


builder.Services.AddScoped<ApplicationContext, ApplicationContext>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//
app.MapControllers();

app.Run();
