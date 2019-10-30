using System.Threading.Tasks;

namespace Cvtex.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}