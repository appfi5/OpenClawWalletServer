using Nethereum.Signer;

namespace SupeRISELocalServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEthereumMessageSigner(this IServiceCollection services)
    {
        services.AddSingleton<EthereumMessageSigner>(p => new EthereumMessageSigner());
        return services;
    }
}