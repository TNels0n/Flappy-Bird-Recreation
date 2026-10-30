using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager sceneInstance;

    private void Awake()
    {
        sceneInstance = this;
    }

    private void OnDestroy()
    {
        if (sceneInstance == this)
        {
            sceneInstance = null;
        }
    }

    public enum Scene
    {
        MainMenu,
        Game
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Game.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
