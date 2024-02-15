using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private const string COIN = "Coin";
    private const string OBSTACLE = "Obstacle";


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(OBSTACLE))
        {
            GameManager.Instance.FinishGame();
            AnimationController.Instance.HitAnimation();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {    
        if (other.CompareTag(COIN))
        {
            GameManager.Instance.score += 2;
        }
        if (other.CompareTag(OBSTACLE))
        {
            GameManager.Instance.FinishGame();
            AnimationController.Instance.HitAnimation();
        }
    }
}
