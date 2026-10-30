using System.Collections;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadzone;
    public bool canDisplaySpeed = true;

    private void Start()
    {
        moveSpeed += LogicScript.logicInstance.pipeSpeedIncreaser;
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator increasePipeSpeed()
    {
        moveSpeed += 10;

        Debug.Log("increasing Speed");

        yield return new WaitForSeconds(5);
    }

    private IEnumerator displaySpeed()
    {
        Debug.Log(moveSpeed);
        moveSpeed += 10;

        yield return new WaitForSeconds(1f);

        canDisplaySpeed = true;

    }

}
