using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader : MonoInstaller
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Game");
    }

    
}
