using System.Collections;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public GameObject BirdWingUp;
    public GameObject BirdWingDown;
    public float flapTimer;
    public Rigidbody2D rigidBody;
    public float flapStength;
    public bool birdIsAlive = true;

    public static birdScript birdInstance;

    private void Awake()
    {
        birdInstance = this;
        Application.targetFrameRate = 120;
    }

    private void OnDestroy()
    {
        if (birdInstance == this)
        {
            birdInstance = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidBody.linearVelocity = Vector2.up * flapStength;
            StartCoroutine(changeBirdWing());
        }

        if (transform.position.y > 35 || transform.position.y < -35)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        if (!birdIsAlive)
        {
            return;
        }

        birdIsAlive = false;
        LogicScript.logicInstance.gameOver();
    }

    private IEnumerator changeBirdWing()
    {
        BirdWingUp.SetActive(false);
        BirdWingDown.SetActive(true);

        yield return new WaitForSeconds(flapTimer);

        BirdWingDown.SetActive(false);
        BirdWingUp.SetActive(true);
    }
}
