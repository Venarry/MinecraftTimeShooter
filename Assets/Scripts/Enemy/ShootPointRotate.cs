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
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y-0.4f, _camera.transform.position.z));
    }
}
