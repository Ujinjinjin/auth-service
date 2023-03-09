namespace AuthService;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.SetupBuilder();

        var app = builder.Build();
        app.SetupApp();

        await app.RunAsync();
    }

    private static WebApplicationBuilder SetupBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Configuration.AddJsonFile(builder.GetAppSettingPath());

        return builder;
    }

    private static string GetAppSettingPath(this WebApplicationBuilder builder)
    {
        return $"AppSettings/appsettings.{builder.GetEnvironmentName()}.json";
    }

    private static string GetEnvironmentName(this WebApplicationBuilder builder)
    {
        return string.IsNullOrWhiteSpace(builder.Environment.EnvironmentName)
            ? "Production"
            : builder.Environment.EnvironmentName;
    }

    private static WebApplication SetupApp(this WebApplication app)
    {
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}