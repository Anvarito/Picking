using System.Collections.Generic;
using Infrastructure.Assets;
using Infrastructure.Components;
using Infrastructure.Factory.Base;
using Infrastructure.Services.Audio;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class InputFactory : GameFactory, IInputFactory
    {
        
        public InputFactory(IAudioService audioService, IAssetLoader assetLoader) : base(audioService, assetLoader)
        {
        }
        
        public override void CleanUp()
        {
            base.CleanUp();
        }
        
    }
}