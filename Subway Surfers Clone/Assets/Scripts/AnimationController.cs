using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public static AnimationController Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void RunAnimation(bool con)
    {
        playerAnimator.SetBool("isRunning",con);
    }

    public void JumpAnimation()
    {
        playerAnimator.SetTrigger("jump");
    }

    public void RollAnimation()
    {
        playerAnimator.SetTrigger("roll");
    }

    public void HitAnimation()
    {
        playerAnimator.SetTrigger("hit");
    }
}
