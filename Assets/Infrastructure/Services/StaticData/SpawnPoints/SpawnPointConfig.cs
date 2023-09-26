using System;
using UnityEngine;

namespace Infrastructure.Services.StaticData.SpawnPoints
{
    [Serializable]
    public class SpawnPointConfig
    {
        public string UniqueId;
        
        public Vector3 Position;
    }
}