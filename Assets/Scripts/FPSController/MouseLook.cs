using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Transform _playerBody;

    private float _verticalRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity") * 2f + 0.2f;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _playerBody.Rotate(Vector3.up * mouseX);

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);        
    }
}
