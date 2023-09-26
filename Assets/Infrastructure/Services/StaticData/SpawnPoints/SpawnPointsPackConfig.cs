using System;
using System.Collections.Generic;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.Services.StaticData.SpawnPoints
{
    [Serializable]
    public class SpawnPointsPackConfig
    {
        public List<SpawnPointConfig> PointsConfigs;
    }
}