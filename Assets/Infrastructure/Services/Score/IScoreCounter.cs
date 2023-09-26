using System;
using System.Collections.Generic;

namespace Infrastructure.Services.Score
{
    public interface IScoreCounter : IService
    {
        public float ScorePlayerOne { get; }
       // void LoadData();
    }
}