using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    public class VictoryState : IState
    {
        private ICargoFactory _cargoFactory;

        public VictoryState(ICargoFactory cargoFactory)
        {
            _cargoFactory = cargoFactory;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _cargoFactory.StopSpawnCargo();
            Debug.Log("VICTORY");
        }
    }
}