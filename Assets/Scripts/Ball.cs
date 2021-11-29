using UnityEngine;

public class Ball : MonoBehaviour
{
    LuanchBall launch;

    private void Awake()
    {
        launch = FindObjectOfType<LuanchBall>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("UnderWall"))
        {
            gameObject.SetActive(false);
            GameManager.instance.numberOfBalls++;
            launch.BallReturn();
        }
    }    
}
