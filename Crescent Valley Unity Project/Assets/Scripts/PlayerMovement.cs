using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] Rigidbody2D playerRigid;
    private Vector2 moveInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        playerRigid.velocity = moveInput * walkSpeed;
    }

    public void EnableMovement(string name)
    {
        playerRigid.WakeUp();
    }
    public void DisableMovement()
    {
        playerRigid.Sleep();
    }
}
