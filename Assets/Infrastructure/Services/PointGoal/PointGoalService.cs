using System.Buffers;
using Infrastructure.Services.StaticData.Level;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure.Services.PointGoal
{
    public class PointGoalService : IPointGoalService
    {
        public UnityAction OnPointsGoal { get; set; }

        private LevelConfig _levelConfig;
        private UnloadingArea _unloadingArea;
        private int points = 0;
        
        public PointGoalService()
        {
            
        }


        public void Setup(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _unloadingArea = Object.FindObjectOfType<UnloadingArea>();
            _unloadingArea.OnEncrease += Encrease;
        }

        private void Encrease()
        {
            points++;
            if (points >= _levelConfig.CargoGoal)
                OnPointsGoal?.Invoke();
        }

        public void CleanUp()
        {
            points = 0;
            _unloadingArea.OnEncrease -= Encrease;
        }

        
    }
}