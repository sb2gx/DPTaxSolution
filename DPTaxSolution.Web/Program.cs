using DPTaxSolution.Core.Interfaces;
using DPTaxSolution.Data;
using DPTaxSolution.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DPTaxSolutionDbContext>();
builder.Services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();
builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddHttpClient("TaxApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7071/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
