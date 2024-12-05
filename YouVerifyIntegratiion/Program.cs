using YouVerifyIntegratiion.Interface;
using YouVerifyIntegratiion.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the IdentityVerificationService to handle both BVN and NIN
builder.Services.AddScoped<IIdentityVerificationService, IdentityVerificationService>();
builder.Services.AddScoped<IBusinessVerificationService, BusinessVerificationService>();
// Register HttpClient and configure it for use in IdentityVerificationService
builder.Services.AddHttpClient<IIdentityVerificationService, IdentityVerificationService>(client =>
{
    // Set the base URL for the YouVerify API
    client.BaseAddress = new Uri(builder.Configuration["YouVerify:BaseUrl"]);
    // Add the API token to the default headers for each request
    client.DefaultRequestHeaders.Add("token", builder.Configuration["YouVerify:ApiToken"]);
});
builder.Services.AddHttpClient<IBusinessVerificationService, BusinessVerificationService>(client =>
{
    // Set the base URL for the YouVerify API
    client.BaseAddress = new Uri(builder.Configuration["YouVerify:BaseUrl"]);
    // Add the API token to the default headers for each request
    client.DefaultRequestHeaders.Add("token", builder.Configuration["YouVerify:ApiToken"]);
});

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
