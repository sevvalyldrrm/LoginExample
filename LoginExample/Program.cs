using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//uygulama ayaða kaldýrýlýrken bir veritabanýna baðlanacaðýný ve bu veritabaný bilgilerini de appsettings'ten okuyacaðýný öðrettik
//options -> datacontext'e gönderilecek parametre yaþam alanýný tutar

builder.Services.AddDbContext<LoginExample.Context.DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr"));
});


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
	pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
