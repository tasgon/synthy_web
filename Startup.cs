using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using synthy.Data;

namespace synthy;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddMvc(options => options.EnableEndpointRouting = false)
        //     .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

        services.AddRazorPages();
        services.AddServerSideBlazor();

        var connString = Configuration.GetConnectionString("Default");
        services.AddDbContext<UserData>(options => options.UseNpgsql(connString));
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
        }).AddEntityFrameworkStores<UserData>();
        
        services.AddSingleton<WeatherForecastService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}