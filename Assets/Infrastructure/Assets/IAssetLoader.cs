using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure.Assets
{
    public interface IAssetLoader : IService
    {
        public GameObject Load(string path);
        
        public GameObject Instantiate(GameObject gameObject);
        
        public T Instantiate<T>(string path) where T : MonoBehaviour;
        public UniTask<T> LoadAsset<T>(string path) where T : MonoBehaviour;
        UniTask LoadAsset(string path, UnityAction<float> progress = null,
            UnityAction<GameObject> onComplete = null);

        UniTask<T> LoadAndInstantiateAsync<T>(string path) where T : MonoBehaviour;
        T LoadAndInstantiate<T>(string path) where T : MonoBehaviour;
    }
}