using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Assets;
using Infrastructure.Factory.Base;
using Infrastructure.Services.Audio;

using UnityEngine;

namespace Infrastructure.Factory
{
    public class EnemyFactory : GameFactory, IEnemyFactory
    {
        public EnemyFactory(IAudioService audioService, IAssetLoader assetLoader) : base(audioService, assetLoader)
        {
            
        }
    }
}