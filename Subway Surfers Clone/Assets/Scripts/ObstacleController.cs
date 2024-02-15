using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float disablePointZ = 0f;
    
    private void Update()
    {
        if (!GameManager.Instance.canPlay){return;}
        
        Move();
        DisableObstacle();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * GameManager.Instance.gameSpeed * Time.deltaTime);
    }

    private void DisableObstacle()
    {
        if (transform.position.z < disablePointZ)
        {
            gameObject.SetActive(false);
        }
    }
}
