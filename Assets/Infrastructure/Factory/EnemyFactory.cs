using Infrastructure.Assets;
using Infrastructure.Factory.Base;

namespace Infrastructure.Factory
{
    public class EnemyFactory : GameFactory, IEnemyFactory
    {
        public EnemyFactory(IAssetLoader assetLoader) : base(assetLoader)
        {
            
        }
    }
}