using Infrastructure.Services.StaticData.Level;
using UnityEngine.Events;

namespace Infrastructure.Services.PointGoal
{
    public interface IPointGoalService : IService
    {
        public UnityAction OnPointsGoal { get; set; }
        void WarmUp(LevelConfig levelConfig);
    }
}