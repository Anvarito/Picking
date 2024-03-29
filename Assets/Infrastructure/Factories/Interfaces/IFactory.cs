using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.Factories
{
    public interface IFactory
    {
        UniTask WarmUp(LevelConfig pendingStageStaticData);
        void CleanUp();

    }
}