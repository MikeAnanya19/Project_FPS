using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f; // Adjust the rotation speed as needed
    public float jumpForce = 5.0f; // Adjust the jump force as needed

    private float rotationX = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze physics rotations
    }

    void Update()
    {
        // Camera Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Camera Rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y + mouseX, 0);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
