using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController c_Controller;
    public float moveSpeed;
    public float jumpForce;

    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }
        float move_x = Input.GetAxis("Horizontal");
        float move_z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * move_x + transform.forward * move_z;
        c_Controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        c_Controller.Move(Time.deltaTime * velocity);
    }
}
