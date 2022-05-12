using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static float mouseSensitivity = 100f;
    public Transform playerTransform;    
    public float smoothing = 1f;

    Quaternion finalRotation; 
    Quaternion initialRotation;
    float xRotation = 0f;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        initialRotation = playerTransform.rotation;
        finalRotation = Quaternion.Euler(0f, mouseX, 0f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerTransform.Rotate(Vector3.up * mouseX);
        playerTransform.rotation = Quaternion.Slerp(initialRotation, finalRotation, smoothing * Time.deltaTime);
    }
}
