using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float speed = 15f;
    public float jumpForce = 20f;

    //[SerializeField] Transform groundCheck;
    //[SerializeField] LayerMask groundLayer;
    private bool canJump = true;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        rb.velocity = transform.TransformDirection(new Vector3(-h, rb.velocity.y, -v));

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

       // void Jump()
       // {
           // rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
           
       // }
    }


    // bool IsGrounded()
    //{
    //    return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    //  }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

}
