using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool crouching = false;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float crouchHeight = 1f;
    private float originalHeight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    public void ProcessMove(Vector2 input)
    {
        // Ground check
        isGrounded = controller.isGrounded;

        // Convert 2D input to 3D movement
        Vector3 moveDirection = new Vector3(input.x, 0f, input.y);
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // Apply gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // stick to ground
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Crouch()
    {
        if (!crouching)
        {
            controller.height = crouchHeight;
            crouching = true;
        }
        else
        {
            controller.height = originalHeight;
            crouching = false;
        }
    }
}
