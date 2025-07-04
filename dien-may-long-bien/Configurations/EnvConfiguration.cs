namespace DienMayLongBien.Configurations;

public static class EnvConfiguration
{
    public static void LoadEnv(this WebApplicationBuilder builder)
    {
        DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
        builder.Configuration.AddEnvironmentVariables();
    }
}
