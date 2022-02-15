using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_camera : MonoBehaviour
{
    public Camera playerCamera;
    public bool canMove = true;
    public float MouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CursorLock();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {

            float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation -= -mouseX;
           
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

}
