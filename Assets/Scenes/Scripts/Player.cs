using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mouseSensitivity = 2f;   
    public float minPitch = -85f;         
    public float maxPitch = 85f;
    public Transform playerBody;
    private float pitch = 0f;
    [SerializeField] private float moveSpeed = 3f;

    private void Start()
    {
        transform.position = new Vector3(0, 1, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");   // A è D
        float z = Input.GetAxis("Vertical");     // W è S

        transform.Translate(new Vector3(x,0,z) * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Cursor.lockState != CursorLockMode.Locked) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

