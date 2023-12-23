namespace MovieHubCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Додайте налаштування логування, якщо потрібно
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Додайте сервіси до контейнера
            builder.Services.AddControllersWithViews();
            // Додайте інші необхідні сервіси

            var app = builder.Build();

            // Налаштуйте HTTP запити
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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

        }
    }
}