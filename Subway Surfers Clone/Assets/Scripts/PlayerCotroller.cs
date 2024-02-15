using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCotroller : MonoBehaviour
{
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float jumpAmout;
    [SerializeField] private List<Transform> lines;
    
    private Rigidbody playerRigidbody;
    private int lineIndex;
    
    
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        lineIndex = 1;     
    }

    private void Update() 
    {
        if (!GameManager.Instance.canPlay){return;}
        
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.A) && lineIndex != 0)
        {
            Vector3 target = new Vector3(lines[lineIndex-1].position.x, transform.position.y, transform.position.z);

            transform.DOMove(target,horizontalMovementSpeed);
            
            lineIndex--;

        }
        else if(Input.GetKeyDown(KeyCode.D) && lineIndex != 2)
        {
            Vector3 target = new Vector3(lines[lineIndex+1].position.x, transform.position.y, transform.position.z);
            
            transform.DOMove(target,horizontalMovementSpeed);
            
            lineIndex++;

        }
    }

    private void MoveVertical()
    {
        if (Input.GetKeyDown(KeyCode.W) && CanJump())
        {
            AnimationController.Instance.JumpAnimation();
            playerRigidbody.AddForce(Vector3.up * jumpAmout, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            AnimationController.Instance.RollAnimation();
            playerRigidbody.AddForce(Vector3.down * jumpAmout, ForceMode.Impulse);
        }
    }

    private bool CanJump()
    {
        if (Physics.Raycast(transform.position,Vector3.down,1))
        {
            return true;
        }
        return false;
    }
}
