using Discord;
using Discord.WebSocket;

using Shoreline.Metrics;
using Shoreline.Providers.Discord;
using Shoreline.Providers.Discord.Variables;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ConfigureServices)
    .ConfigureAppConfiguration(ConfigureApplication);

var host = builder.Build();
host.Run();

return;

static void ConfigureApplication(HostBuilderContext context,
    IConfigurationBuilder configuration) =>
    configuration.AddEnvironmentVariables(nameof(Shoreline))
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

static void ConfigureServices(IServiceCollection services) => services
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton<IDiscordClient>(provider => provider.GetRequiredService<DiscordSocketClient>())
    .AddSingleton<IEnvironmentVariable<DiscordToken>, DiscordToken>()
    .AddHostedService<DiscordBot>();