using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (transform.parent == null)
        {
            _rigidbody.isKinematic = false;
        }
        else _rigidbody.isKinematic = true;
    }
}
