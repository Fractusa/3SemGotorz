namespace Gotorz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllersWithViews();  // or AddMvc(), etc.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            
            app.UseRouting();

            // (optional) auth, cors, etc:
            // app.UseAuthentication();
            // app.UseAuthorization();
            // app.UseCors("YourCorsPolicy");

            // 2. Map your SignalR hubs (and MVC, Razor, etc.)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapDefaultControllerRoute();  // or MapControllers(), MapRazorPages(), etc.
            });
        }
    }
}
