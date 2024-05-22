using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] Animator anim;

    private bool facingLeft = true;
    private Vector2 lastMoveDirection;
    private Vector2 moveInput;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Inputs();
        Animation();

        if (moveInput.x < 0 && facingLeft == false || moveInput.x > 0 && facingLeft == true)
        {
            //FlipSprite();
        }
        
    }

    public void EnableMovement(string name)
    {
        playerRigid.WakeUp();
    }
    public void DisableMovement()
    {
        playerRigid.Sleep();
    }

    private void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (moveInput.x !=0 || moveInput.y != 0))
        {
            print("Player Stopped");
            lastMoveDirection = moveInput;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        playerRigid.velocity = moveInput * walkSpeed;
    }

    private void Animation()
    {
        anim.SetFloat("moveX", moveInput.x);
        anim.SetFloat("moveY", moveInput.y);
        anim.SetFloat("moveMagnitude", moveInput.magnitude);
        anim.SetFloat("lastMoveX", lastMoveDirection.x);
        anim.SetFloat("lastMoveY", lastMoveDirection.y);
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = false;
    }
}
