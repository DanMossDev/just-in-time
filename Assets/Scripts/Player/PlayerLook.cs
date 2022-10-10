using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    Camera mainCamera;
    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = GetComponentInChildren<Camera>();
    }

    void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        xRotation -= input.y * PlayerSettings.mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.Rotate(Vector3.up * input.x * PlayerSettings.mouseSensitivity);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
