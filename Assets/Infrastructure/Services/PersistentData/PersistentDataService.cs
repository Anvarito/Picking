﻿using Data;

namespace Infrastructure.Services.PersistentData
{
    public class PersistentDataService : IPersistentDataService
    {
        public PlayerSettingsData Settings { get; set; }
        public PlayerProgressData Progress { get; set; }
        public PlayerEconomyData Economy { get; set; }
    }
}