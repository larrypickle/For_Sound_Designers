using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public CharacterController controller;
    public Camera camera;
    
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    Vector3 velocity;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float verticalVelocity;
    public float jumpForce = 20.0f;

    private float x;
    private float z;

    PlayerHealth health;

    // Update is called once per frame
    void Update()
    {
        //is grounded check doesnt work
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //jump (Fix this later)
        /*if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMP");
            verticalVelocity = Mathf.Sqrt(jumpForce * -2.0f * gravity);
        }
        else if (isGrounded && velocity.y < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            //Debug.Log("Gravity work");
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }
        velocity.y = verticalVelocity;*/
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        
        //actual movement 
        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
    }


}

