using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public float pipeSpeedIncreaser;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject mainMenuScreen;
    public AudioSource dingSFX;
    public AudioSource StartSFX;
    public int globalTimer;
    public bool canIncrement;
    public bool canIncreaseSpeed;

    public static LogicScript logicInstance;

    private void Awake()
    {
        logicInstance = this;
    }

    private void OnDestroy()
    {
        if (logicInstance == this)
        {
            logicInstance = null;
        }
    }

    private void Update()
    {
        if (globalTimer % 2 == 0 && canIncreaseSpeed && globalTimer > 1)
        {
            canIncreaseSpeed = false;
            StartCoroutine(increaseSpeed());
        }
        if (canIncrement == true)
        {
            canIncrement = false;
            StartCoroutine(incrementGlobalTimer());
        }
    }

    [ContextMenu("increase score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        dingSFX.Play();
    }

    public void restartGame()
    {
        StartSFX.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private IEnumerator incrementGlobalTimer()
    {
        globalTimer++;

        yield return new WaitForSeconds(1f);

        canIncrement = true;
    }

    private IEnumerator increaseSpeed()
    {
        pipeSpeedIncreaser += 1;
        Debug.Log("increasing Speed");

        yield return new WaitForSeconds(1f);

        canIncreaseSpeed = true;
    }
}
