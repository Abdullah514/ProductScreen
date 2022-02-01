using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AuthenticationDbContextContextConnection");
builder.Services.AddDbContext<DatabaseContaxt>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

//builder.Services.AddDefaultIdentity<appiUser>(
//    options => options.SignIn.RequireConfirmedAccount = true
  //  )
   //.AddEntityFrameworkStores<DatabaseContaxt>();



//builder.Services.AddDbContext<DatabaseContaxt>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContaxt")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
