using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform trans;
    public Rigidbody rb;
    public float movementSpeed = 50f;
    public float runningSpeed = 1.5f;
    public float jumpForce = 8f;

    private bool isJumping = false;
    
    void Start()
    {
        trans = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float currentMovementSpeed = movementSpeed;
        // Check if the Player is Running (Left Shift Key Pressed)
        if (Input.GetKey(KeyCode.LeftShift)) { 
            currentMovementSpeed = movementSpeed * runningSpeed;
        }
        // Move to the direction asked when Key is Pressed...
        if (Input.GetKey(KeyCode.A)) {
            trans.position -= trans.right * currentMovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            trans.position += trans.right * currentMovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)) {
            trans.position += trans.forward * currentMovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            trans.position -= trans.forward * currentMovementSpeed * Time.deltaTime;
        }
        if (!isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * jumpForce);
        }
    }

    void OnCollisionEnter(Collision target)
    {
        isJumping = !target.gameObject.CompareTag("Ground");
    }

    void OnCollisionExit(Collision target)
    {
        isJumping = target.gameObject.CompareTag("Ground");
    }
}
