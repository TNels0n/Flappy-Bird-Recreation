using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _endGame;

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);
        _endGame.onClick.AddListener(EndGame);
    }

    private void OnDisable()
    {
        _startGame.onClick.RemoveListener(StartGame);
        _endGame.onClick.RemoveListener(EndGame);
    }

    private void StartGame()
    {
        ScenesManager.sceneInstance.LoadNewGame();
    }

    private void EndGame()
    {
        ScenesManager.sceneInstance.ExitGame();
    }

}
