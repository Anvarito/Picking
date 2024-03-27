﻿using Data;

namespace Infrastructure.Services.PersistentData
{
    public interface IPersistentDataService
    {
        PlayerSettingsData Settings { get; set; }
        PlayerProgressData Progress { get; set; }
        PlayerEconomyData Economy { get; set; }
    }
}