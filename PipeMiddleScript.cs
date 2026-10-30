using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && birdScript.birdInstance.birdIsAlive)
        {
            LogicScript.logicInstance.addScore(1);
        }
    }
}
