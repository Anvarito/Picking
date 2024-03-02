using System;
using System.Collections.Generic;
using Infrastructure.Factory.Base;
using Infrastructure.Services;
using Infrastructure.Services.KillCounter;
using Infrastructure.Services.Score;

namespace Infrastructure.Factory.Compose
{
    public class Factories : IFactories
    {
        public Dictionary<Type, IGameFactory> All { get; } = new Dictionary<Type, IGameFactory>();

        public void Add<TFactory>(TFactory factory) where TFactory : IGameFactory =>
            All.Add(typeof(TFactory), factory);

        public TFactory Single<TFactory>() where TFactory : class, IGameFactory =>
            All[typeof(TFactory)] as TFactory;

        public void CleanUp()
        {
        }
    }

    public interface IBattleServicesFacade : IService
    {
        public IKillCounter KillCounter { get; }
        public IScoreCounter ScoreCounter { get; }

    }
    
    public class BattleServicesFacade : IBattleServicesFacade
    {
        public IKillCounter KillCounter { get; }

        public IScoreCounter ScoreCounter { get; }

        public BattleServicesFacade(IKillCounter killCounter, IScoreCounter scoreCounter)
        {
            KillCounter = killCounter;
            ScoreCounter = scoreCounter;
        }

        public void CleanUp()
        {
        }
    }
}