namespace WarehouseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var con = builder.Configuration.GetConnectionString("Default") ??
               throw new InvalidOperationException("not database found");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(con));
            builder.Services.AddScoped<ITendersService , TendersService>();
            builder.Services.AddScoped<IRequireditemsService , RequireditemsService>();
            builder.Services.AddScoped<ICommitteesService , CommitteesService>();
            builder.Services.AddScoped<IMembersService , MembersService>();
            builder.Services.AddScoped<IVendorsService , VendorsService>();
            builder.Services.AddScoped<IOffersService , OffersService>();
            builder.Services.AddScoped<IAlternativeItemsService, AlternativeItemsService>();
            builder.Services.AddScoped<IAcceptItemsService , AcceptItemsService>();
            builder.Services.AddScoped<IReceiveItemsService , ReceiveItemsService>();
            builder.Services.AddScoped<IStoreItemsService , StoreItemsService>();
            builder.Services.AddScoped<ICovenantItemsService , CovenantItemsService>();
            builder.Services.AddScoped<IAccountsService , AccountsService>();
            builder.Services.AddScoped<IEntitysService , EntitysService>();
            builder.Services.AddScoped<IExpiritionProccesService , ExpiritionProccesService>();
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
              //   pattern: "{controller=Account}/{action=Login}/{id?}");
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
