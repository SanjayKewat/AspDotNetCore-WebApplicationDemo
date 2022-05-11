using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();

//here DbContextPool, it resuse the DBcontext that has create while the app is alive,
//OdeToFoodDbContext take as constructor parameter to initialized it & pass connectionstring name 
builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("OdeToFoodDb"));
});

//here register/inject the service, call dependency Injection
builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();
var app = builder.Build();

//here declare middleware, all are middleware after app.(variable)
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();  //allow established secure connections
}

app.MapControllers(); //without adding this api controller not working
app.UseHttpsRedirection();
app.UseStaticFiles();  //install static files & used it

app.UseRouting();

app.UseAuthorization();
app.UseCookiePolicy(); //this method allow to used cookie in the application
app.UseAuthentication();
app.MapRazorPages();

app.Run();