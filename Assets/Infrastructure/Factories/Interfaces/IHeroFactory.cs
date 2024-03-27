using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories
{
    public interface IHeroFactory : IFactory
    {
        GameObject Hero { get; }
    }
}