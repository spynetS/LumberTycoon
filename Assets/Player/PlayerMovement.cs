using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float lookSensitivity = 3f;

    [SerializeField] private bool isGrounded;
    
    private Rigidbody rb;
    private Camera playerCamera;
    private float xRotation = 0f;
    private float move_X;
    private float move_Z;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }else
        {
            moveSpeed = 5;
        }

        if (!Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }

        move_X = Input.GetAxis("Horizontal") * (moveSpeed * Time.deltaTime);
        move_Z = Input.GetAxis("Vertical") * (moveSpeed * Time.deltaTime);


        Move();
    }

    private void Move()
    {
        transform.Translate(move_X, 0, 0);
        transform.Translate(0, 0, move_Z);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
