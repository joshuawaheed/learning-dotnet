namespace AlloyDemo;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            // tell Kestrel to listen on 127.0.0.1 for requests to
            // port 801 e.g. http://www.alloy.com:801/
            .ConfigureWebHost(options =>
            {
                options.ConfigureKestrel(options =>
                {
                    options.Listen(System.Net.IPAddress.Loopback, 801);
                });
            });
}
