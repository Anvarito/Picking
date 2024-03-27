using Cysharp.Threading.Tasks;

namespace Infrastructure.Factories.Interfaces
{
    public interface ICargoFactory : IFactory
    {
        UniTask SpawnCargo();
    }
}