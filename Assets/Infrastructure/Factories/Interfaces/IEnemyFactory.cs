using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories
{
    public interface IEnemyFactory : IFactory
    {
        //Task<GameObject> Create(EnemyType enemyType, Transform parent);
    }
}