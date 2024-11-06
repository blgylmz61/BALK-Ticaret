using BALK_Ticaret.Mappings;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using BLL.Mappings;
using DAL.AbstractRepository;
using DAL.ConcerteRepository;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IUserDetailService), typeof(UserDetailService));
builder.Services.AddScoped(typeof(IUserRoleService), typeof(UserRoleService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddScoped(typeof(IGenderService), typeof(GenderService));
builder.Services.AddScoped(typeof(IAddressService), typeof(AddressService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
builder.Services.AddScoped(typeof(ICardService), typeof(CardService));








builder.Services.AddSession();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(MapperProfile));

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
