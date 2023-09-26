using System;
using System.Collections.Generic;
using Infrastructure.Assets;
using Infrastructure.Factory.Compose;
using Infrastructure.Services;
using Infrastructure.Services.Audio;
using Infrastructure.Services.Input;
using Infrastructure.Services.KillCounter;
using Infrastructure.Services.Progress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Timer;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ServiceLocator services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, coroutineRunner, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader,services.Single<IAudioService>(), services.Single<IProgressService>(), services.Single<IStaticDataService>(), services.Single<IFactories>(), services.Single<IScoreCounter>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IProgressService>(), services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this, services.Single<IInputService>(), services.Single<ITimerService>(), services.Single<IKillCounter>(), services.Single<IScoreCounter>(), services.Single<IProgressService>(), services.Single<IStaticDataService>(), services.Single<IFactories>()),
                [typeof(VictoryState)] = new VictoryState(this, coroutineRunner,services.Single<IAudioService>(),services.Single<ITimerService>(),services.Single<IInputService>(), services.Single<IFactories>(), services.Single<IProgressService>(), services.Single<ISaveLoadService>()),
                [typeof(DefeatState)] = new DefeatState(this, coroutineRunner, services.Single<IFactories>(), services.Single<ITimerService>(), services.Single<IProgressService>(), services.Single<IInputService>(), services.Single<ISaveLoadService>(), services.Single<IAudioService>()),
            };
        }
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();

            LogState<TState>();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
            
            LogState<TState>();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }

        private void LogState<TState>() where TState : class, IExitableState =>
            Debug.Log($"Entered {typeof(TState).Name}");
    }
}