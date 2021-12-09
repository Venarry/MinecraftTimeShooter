using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPointRotate : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.LookAt(_camera.transform.position);
    }
}
