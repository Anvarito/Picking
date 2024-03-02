using Infrastructure.Assets;
using Infrastructure.Factory.Base;
using Infrastructure.Services.Input;

namespace Infrastructure.Factory
{
    public class InputFactory : GameFactory, IInputFactory
    {
        private readonly IAssetLoader _assetLoader;

        public IInputService InputService { get; }
        
        public InputFactory(IInputService inputService, IAssetLoader assetLoader) : base(assetLoader)
        {
            _assetLoader = assetLoader;
            InputService = inputService;
        }
        
        public override void CleanUp()
        {
            base.CleanUp();
        }

    }
}