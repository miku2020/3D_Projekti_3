using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Controller : MonoBehaviour
{
    //https://www.youtube.com/watch?v=_QajrabyTJc

    public CharacterController controller;

    public Transform cameratrans;
    bool isGrounded;
    public LayerMask groundMask;
    public float groundDistance;
    public Transform groundCheck;

    Vector3 velocity;
    public float speed;
    public float gravity;
    public float maxspeed;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 rght = cameratrans.right;
        Vector3 frwrd = Vector3.Cross(rght, Vector3.up * -gravity);
        Vector3 move = (rght * (x * 5) + frwrd * z) * speed * Time.deltaTime;

        velocity.y += gravity * Time.deltaTime;

        if (velocity.y <= maxspeed)
        {
            // Debug.Log("maxpeed reached");
            velocity.y = maxspeed;
        }
        else if (velocity.y >= -maxspeed)
        {
            //Debug.Log("maxpeed reached");
            velocity.y = -maxspeed;
        }
        
        controller.Move(move + velocity * Time.deltaTime);
    }
}
