using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMoveLerp : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
