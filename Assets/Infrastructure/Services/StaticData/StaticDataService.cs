using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.Audio;
using Infrastructure.Services.StaticData.Audio;
using Infrastructure.Services.StaticData.Level;
using Infrastructure.Services.StaticData.SpawnPoints;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public Dictionary<string, LevelConfig> Levels { get; private set; }

        private const string LevelDataPath = "StaticData/Levels";

        private Dictionary<MusicId, MusicConfig> _music;
        private Dictionary<SoundId, SoundConfig> _sounds;


        public void LoadAllStaticData()
        {
            Levels = Resources
                .LoadAll<LevelStaticData>(LevelDataPath)
                .Select(x => x.Config)
                .ToDictionary(x => x.SceneName, x => x);

            Debug.Log("Static data loaded");
        }

        public SoundConfig ForSounds(SoundId id) =>
            _sounds.TryGetValue(id, out SoundConfig config)
                ? config
                : null;

        public MusicConfig ForMusic(MusicId id) =>
            _music.TryGetValue(id, out MusicConfig config)
                ? config
                : null;

       
        public LevelConfig ForLevel(string id) =>
            Levels.TryGetValue(id, out LevelConfig config)
                ? config
                : null;

        public void CleanUp()
        {
        }
    }
}