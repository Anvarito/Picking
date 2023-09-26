using System.Collections.Generic;
using Infrastructure.Services.Audio;
using Infrastructure.Services.StaticData.Audio;
using Infrastructure.Services.StaticData.Level;
using Infrastructure.Services.StaticData.SpawnPoints;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadAllStaticData();
        LevelConfig ForLevel(string id);
        //GamemodeConfig ForMode(GamemodeId id);
        Dictionary<string, LevelConfig> Levels { get; }
       // List<SpawnPointConfig> ForLevelAndMode(LevelId id1, GamemodeId id2);
        MusicConfig ForMusic(MusicId id);
        SoundConfig ForSounds(SoundId id);
    }
}