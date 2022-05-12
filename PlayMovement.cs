using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprintMultiplier = 2f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(move * speed * sprintMultiplier * Time.deltaTime);
            }
            else
            {
                controller.Move(move * speed * Time.deltaTime);
            }            

            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.ReloadScene();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Message.ShowMessage("tippy boingo woingo");
            }
        }        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.layer == 9 && hit.normal.y >= 0.6f)
        {
            //Debug.Log(hit.normal);
        }
    }
}
