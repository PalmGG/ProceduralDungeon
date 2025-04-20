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
    public float moveSpeedmulti = 1f;

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
        moveSpeed = this.GetComponent<PlayerStats>().speed;
        rb.linearVelocity = new Vector3(movementDirection.x * ((moveSpeed / 10) * moveSpeedmulti), rb.linearVelocity.y - Grav + jumpforce, movementDirection.z * ((moveSpeed / 10) * moveSpeedmulti));
        jumpforce = 0;
    }

    void OnSprint()
    {
        moveSpeedmulti = 1.3f;
    }
    void OnSprintRel()
    {
        moveSpeedmulti = 1f;
    }
    void OnJump()
    {
        if (isGrounded() == true)
        {
            jumpforce = 20;
        }
    }

}
