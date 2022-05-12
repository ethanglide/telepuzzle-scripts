using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    Quaternion finalRotation;
    Quaternion initialRotation;

    public Transform cam;

    public float smoothing = 10f;
    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseLook.mouseSensitivity * Time.deltaTime;

        initialRotation = transform.rotation;
        finalRotation = Quaternion.Euler(0f, mouseX - 93f, -cam.rotation.eulerAngles.x + 2f);

        //Debug.Log($"{initialRotation}\n{finalRotation}");

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);                
        transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, smoothing * Time.deltaTime);
    }
}
