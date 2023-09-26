using System;
using System.Collections.Generic;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;
        public string Level;
        public float MusicVolume;
        public float SoundsVolume;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel, null);
            MusicVolume = 10;
            SoundsVolume = 10;
        }

    }
}