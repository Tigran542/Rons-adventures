using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField] float speed = 15f;
    [SerializeField] float jumpForce = 20f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        _rb.velocity = transform.TransformDirection(new Vector3(-h, _rb.velocity.y, -v));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        void Jump()
        {
            _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
        }
    }


    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

}
