using Infrastructure.Services.Input;

namespace Infrastructure.Factory.Base
{
    public interface IInputFactory : IGameFactory
    {
        public IInputService InputService { get; }
    }
}