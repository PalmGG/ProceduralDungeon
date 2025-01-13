using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFinalSystem : MonoBehaviour
{
    float Grav = 0;
    private Rigidbody rb;
    public float moveSpeed;
    private Vector2 inputDirection;
    private Vector3 movementDirection;
    public InputActionReference move;
    public float castDistance;
    public LayerMask groundLayer;
    public float jumpforce = 0;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        inputDirection = move.action.ReadValue<Vector2>();
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        movementDirection = transform.TransformDirection(movementDirection);

    }

    public bool isGrounded()
    {
      if (Physics.Raycast(transform.position, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isGrounded() == false)
        {
            Grav = 0.4f;
        }
        else
        {
            Grav = 0;
        }
        rb.linearVelocity = new Vector3(movementDirection.x * moveSpeed, rb.linearVelocity.y - Grav + jumpforce, movementDirection.z * moveSpeed);
        jumpforce = 0;
    }

    void OnJump()
    {
        Debug.Log("Jamp");
        if (isGrounded() == true)
        {
            jumpforce = 20;
        }
    }
    
}
