using Infrastructure.Constants;
using Infrastructure.SceneManagement;

namespace Infrastructure.States.MainStates
{
    public class MenuState : IState
    {
        private SceneLoader _sceneLoader;

        public MenuState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(SceneNameConstants.Menu, onLoaded: OnLoaded);
        }

        private void OnLoaded()
        {
           
        }

        public void Exit()
        {
           
        }
    }
}