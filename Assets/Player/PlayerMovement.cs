using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 10;
    public float walkSpeed = 5;
    private float moveSpeed = 15f;
    public float jumpForce = 10f;
    public float lookSensitivity = 3f;
    
    [Header("Sound")]
    private AudioSource playerAudio;
    public float volume;
    public AudioClip footstep;

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
        playerAudio = GetComponent<AudioSource>();
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

        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = runSpeed;
        }else{
            moveSpeed = walkSpeed;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else{
            transform.localScale = new Vector3(1, 1, 1);
        } 

        if (!Cursor.visible) {
            Cursor.lockState = CursorLockMode.Locked;
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        rb.velocity = (movement * (moveSpeed * 50 * Time.fixedDeltaTime)) + new Vector3(0f, rb.velocity.y, 0f);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAudio.PlayOneShot(footstep, volume);
        }
    }
}
