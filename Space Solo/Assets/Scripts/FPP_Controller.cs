using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPP_Controller : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameratrans;
    bool isGrounded;
    public LayerMask groundMask;
    public float groundDistance;
    public Transform groundCheck;

    Vector3 velocity;
    public float speed;
    public float gravity;
    public float maxspeed;

    Vector2 previousInput;
    bool hasLoggedInput;
    bool hasLoggedMissingReferences;
    bool hasLoggedMissingDevices;

    void OnEnable()
    {
        Debug.Log(
            $"[Input Debug] {name}: FPP_Controller enabled={isActiveAndEnabled}, " +
            $"keyboard={Keyboard.current != null}, gamepad={Gamepad.current != null}, " +
            $"controllerAssigned={controller != null}, cameraAssigned={cameratrans != null}, " +
            $"groundCheckAssigned={groundCheck != null}.",
            this);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null || cameratrans == null || groundCheck == null)
        {
            if (!hasLoggedMissingReferences)
            {
                Debug.LogError(
                    $"[Input Debug] {name}: movement stopped because CharacterController, " +
                    "camera Transform, or Ground Check is not assigned.",
                    this);
                hasLoggedMissingReferences = true;
            }

            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 input = Vector2.zero;
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            input.x += (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed ? 1f : 0f)
                - (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed ? 1f : 0f);
            input.y += (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed ? 1f : 0f)
                - (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed ? 1f : 0f);
        }

        Gamepad gamepad = Gamepad.current;
        if (gamepad != null)
        {
            input += gamepad.leftStick.ReadValue();
        }

        if (keyboard == null && gamepad == null)
        {
            if (!hasLoggedMissingDevices)
            {
                Debug.LogWarning(
                    $"[Input Debug] {name}: no current keyboard or gamepad detected.",
                    this);
                hasLoggedMissingDevices = true;
            }
        }
        else
        {
            hasLoggedMissingDevices = false;
        }

        input = Vector2.ClampMagnitude(input, 1f);
        bool inputChanged = !hasLoggedInput || input != previousInput;
        if (inputChanged)
        {
            Debug.Log(
                $"[Input Debug] {name}: movement input={input}, keyboard={keyboard != null}, " +
                $"gamepad={gamepad != null}, focused={Application.isFocused}.",
                this);
            previousInput = input;
            hasLoggedInput = true;
        }

        float x = input.x;
        float z = input.y;

        Vector3 right = cameratrans.right;
        right.y = 0f;
        right.Normalize();
        Vector3 forward = Vector3.Cross(right, Vector3.up);
        // Alkuperäinen liike oli molempiin suuntiin 5-kertainen (x * 5 ja painovoimasta tullut forward-pituus).
        Vector3 move = (right * x + forward * z) * 5f * speed * Time.deltaTime;

        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, maxspeed);

        Vector3 displacement = move + velocity * Time.deltaTime;
        CollisionFlags collisions = controller.Move(displacement);
        if (input != Vector2.zero && inputChanged)
        {
            Debug.Log(
                $"[Input Debug] {name}: CharacterController.Move called with displacement=" +
                $"{displacement}, collisions={collisions}.",
                this);
        }
    }
}
