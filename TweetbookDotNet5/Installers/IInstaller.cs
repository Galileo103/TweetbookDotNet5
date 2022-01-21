using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TweetbookDotNet5.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
