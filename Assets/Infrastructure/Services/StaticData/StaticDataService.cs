using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.StaticData.Level;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public Dictionary<string, LevelConfig> Levels { get; private set; }

        private const string LevelDataPath = "StaticData/Levels";

        public void LoadAllStaticData()
        {
            Levels = Resources
                .LoadAll<LevelStaticData>(LevelDataPath)
                .Select(x => x.Config)
                .ToDictionary(x => x.SceneName, x => x);

            Debug.Log("Static data loaded");
        }
       
        public LevelConfig ForLevel(string id) =>
            Levels.TryGetValue(id, out LevelConfig config)
                ? config
                : null;

        public void CleanUp()
        {
        }
    }
}