using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private float disablePointZ = 1f;
    private float extraSpeed = 8;
    
    private void Update()
    {
        if (!GameManager.Instance.canPlay){return;}
        
        Move();
        DisableObstacle();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * (GameManager.Instance.gameSpeed + extraSpeed) * Time.deltaTime);
    }

    private void DisableObstacle()
    {
        if (transform.position.z < disablePointZ)
        {
            gameObject.SetActive(false);
        }
    }
}
