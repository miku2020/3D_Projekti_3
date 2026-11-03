using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPP_camera : MonoBehaviour
{
    public Camera playerCamera;
    public bool canMove = true;
    public float MouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    bool hasLoggedMissingMouse;
    bool hasLoggedBlockedMovement;

    void OnEnable()
    {
        Debug.Log(
            $"[Input Debug] {name}: FPP_camera enabled={isActiveAndEnabled}, " +
            $"mouse={Mouse.current != null}, canMove={canMove}, " +
            $"sensitivity={MouseSensitivity}, focused={Application.isFocused}.",
            this);
    }

    // Start is called before the first frame update
    void Start()
    {
        CursorLock();
        Debug.Log(
            $"[Input Debug] {name}: camera Start ran; cursor lock state={Cursor.lockState}.",
            this);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Mouse mouse = Mouse.current;
            if (mouse == null)
            {
                if (!hasLoggedMissingMouse)
                {
                    Debug.LogWarning($"[Input Debug] {name}: no current mouse detected.", this);
                    hasLoggedMissingMouse = true;
                }

                return;
            }

            hasLoggedMissingMouse = false;
            Vector2 rawMouseDelta = mouse.delta.ReadValue();
            Vector2 mouseDelta = rawMouseDelta * MouseSensitivity * 0.1f;
            if (rawMouseDelta != Vector2.zero)
            {
                Debug.Log(
                    $"[Input Debug] {name}: mouse input received raw={rawMouseDelta}, " +
                    $"applied={mouseDelta}, cursor={Cursor.lockState}, " +
                    $"focused={Application.isFocused}.",
                    this);
            }

            xRotation -= mouseDelta.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation += mouseDelta.x;

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        else if (!hasLoggedBlockedMovement)
        {
            Debug.LogWarning(
                $"[Input Debug] {name}: camera input ignored because canMove is false.",
                this);
            hasLoggedBlockedMovement = true;
        }
    }

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log($"[Input Debug] {name}: cursor unlocked.", this);
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log($"[Input Debug] {name}: cursor locked.", this);
    }
}
