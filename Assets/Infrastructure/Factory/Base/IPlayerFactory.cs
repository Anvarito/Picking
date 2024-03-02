namespace Infrastructure.Factory.Base
{
    public interface IPlayerFactory : IGameFactory
    {
        public void CreatePlayer();
    }
}