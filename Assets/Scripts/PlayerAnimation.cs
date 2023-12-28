using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animator;

    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    void OnMove()
    {
        if (player.Direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                OnRolling();
            }
            else
            {
                OnWalk();
            }
        }
        else
        {
            OnIdle();
        }

        //If the player is walking to the left direction
        if (player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        //If the player is walking to the right direction
        if (player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnWalk()
    {
        animator.SetInteger("transition", 1);
    }

    void OnIdle()
    {
        animator.SetInteger("transition", 0);
    }

    void OnRolling()
    {
        animator.SetTrigger("isRoll");
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            animator.SetInteger("transition", 2);
        }
    }

}
