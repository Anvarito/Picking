using System.Collections.Generic;
using Infrastructure.Assets;
using UnityEngine;

namespace Infrastructure.Factory.Base
{
    public abstract class GameFactory : IGameFactory
    {

        protected readonly IAssetLoader _assetLoader;

        protected GameFactory( IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        
        public virtual void CleanUp()
        {
        }
        
        protected GameObject InstantiateRegistered(string path, Vector3 position)
        {
            GameObject gameObject = _assetLoader.Instantiate(path, at: position);
            ConstructAudioEmitters(gameObject);
            return gameObject;
        }

        protected GameObject InstantiateRegistered(string path)
        {
            GameObject gameObject = _assetLoader.Instantiate(path);
            ConstructAudioEmitters(gameObject);
            return gameObject;
        }
        
        protected TComponent InstantiateRegistered<TComponent>(string path) where TComponent : MonoBehaviour
        {
            TComponent component = _assetLoader.Instantiate<TComponent>(path);
            ConstructAudioEmitters(component.gameObject);
            return component;
        }

        private void ConstructAudioEmitters(GameObject componentGameObject)
        {
            
        }

       
    }
}