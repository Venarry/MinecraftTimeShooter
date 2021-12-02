using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ViewChecker))]
public class EnemyLook : MonoBehaviour
{
    private Camera _camera;
    private ViewChecker _viewChecker;
    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _viewChecker = GetComponent<ViewChecker>();
    }
    private void Update()
    {
        if(_viewChecker.IsView())
        {
            Quaternion targetPoint = Quaternion.LookRotation(_camera.transform.position - transform.position);
            targetPoint.x = 0;
            targetPoint.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint, 20*Time.deltaTime);
        }
    }
}
