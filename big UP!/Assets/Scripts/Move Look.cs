using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLook : MonoBehaviour
{
    
	public float movementSpeed = 2f;
    [SerializeField] private CharacterController controller;
    public Transform Camera;
    public Transform body;
    private float rotationX = 0f;
    private float rotationY = 0f;
    [SerializeField] private float mouseSensitivity = 2.0f;
    private float minX = -90f;
    private float maxX = 0f; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            Cursor.lockState = CursorLockMode.None;  
        }
        if (Input.GetMouseButtonDown(1))
        {    
            Cursor.lockState = CursorLockMode.Locked;  
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minX, -minX);
        Camera.localRotation = Quaternion.Euler(rotationX, 0, 0);

        rotationY += mouseX;
        body.rotation = Quaternion.Euler(0, rotationY, 0);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = body.right * moveX + body.forward * moveZ;
        move.y = 0;
        controller.Move(move.normalized * movementSpeed * Time.deltaTime);
    }

}
