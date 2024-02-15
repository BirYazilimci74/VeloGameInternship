using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float translatePointZ = -92f;
    private float platformLength = 90f;

    
    private void Update() 
    {
        if (!GameManager.Instance.canPlay){return;}
        
        MovePlatform();
        TranslatePlatform();   
    }

    private void MovePlatform()
    {
        transform.Translate(Vector3.back * GameManager.Instance.gameSpeed * Time.deltaTime);
    }

    private void TranslatePlatform()
    {
        if(transform.position.z < translatePointZ)
        {
            Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z + platformLength * 2);
            transform.position = newPosition;
        }
    }
}
