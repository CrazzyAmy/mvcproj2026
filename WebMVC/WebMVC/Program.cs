using WebMVC.Filters;

namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<Interface.IBookService, Models.BookService_V1>();
            // builder.Services.AddScoped<Interface.IBookService, Models.BookService_V2>();
            // builder.Services.AddTransient<Interface.IBookService, Models.BookService_V2>();

            // 註冊 AuthorizationFilter 到 DI 容器（供 ServiceFilter 使用）
            builder.Services.AddScoped<Filters.AuthorizationFilter>();
            builder.Services.AddScoped<Filters.TimestampActionFilter>();


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


            app.UseMiddleware<RequestLoggingMiddleware>(); // 使用自訂中介軟體-請求日誌記錄

            app.UseRouting();//屬性路由

           //app.UseAuthentication(); //身份驗證-signin
            app.UseAuthorization(); //權限驗證

          
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("1st Middleware In\n");
            //    await next.Invoke();
            //    Console.WriteLine("1st Middleware Out \n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("2nd Middleware In\n");
            //    await next.Invoke();
            //    Console.WriteLine("2nd Middleware Out \n");
            //});


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
