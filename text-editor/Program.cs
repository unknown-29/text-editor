using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using text_editor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringTmp = builder.Configuration.GetConnectionString("DefaultConnection");
connectionStringTmp= connectionStringTmp.Replace("SERVER_ENV", Environment.GetEnvironmentVariable("Server"));
connectionStringTmp = connectionStringTmp.Replace("DATABASE_ENV", Environment.GetEnvironmentVariable("Database"));
connectionStringTmp = connectionStringTmp.Replace("USER_ENV", Environment.GetEnvironmentVariable("User"));
connectionStringTmp = connectionStringTmp.Replace("PASSWORD_ENV", Environment.GetEnvironmentVariable("Password"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionStringTmp, ServerVersion.AutoDetect(connectionStringTmp)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
