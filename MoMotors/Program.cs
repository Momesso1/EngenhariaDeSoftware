using Microsoft.EntityFrameworkCore;
using MoMotors.Areas.Identity.Data;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MoMotorsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoMotorsDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MoMotorsDbContextConnection' not found."));
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IVeiculosRepositorio, VeiculosRepositorio>();
builder.Services.AddScoped<IChatIARepositorio, ChatIARepositorio>();


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<MoMotorsDbContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Identity",
    pattern: "{area:exists}/{controller=Account}/{action=Register}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
