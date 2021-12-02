using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform[] _shakePoints;
    [SerializeField] private float _speedShake;
    [SerializeField] private float _timeToSwitch;
    private Transform _startPosition;
    private CharacterController _characterController;
    [SerializeField] private int _currentPoint;
    private bool _direction;
    private void Start()
    {
        _characterController = GetComponentInParent<CharacterController>();
        _startPosition = transform;
    }

    private void Update()
    {
        MoveShake();
    }

    private void MoveShake()
    {
        if (_characterController.velocity != Vector3.zero)
        {
            Vector3 targetPosition = _shakePoints[_currentPoint].position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speedShake * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, _shakePoints[_currentPoint].position) <= 0.05f)
        {
            SwitchPoint();
        }
    }
    private void SwitchPoint()
    {
        if (_currentPoint == _shakePoints.Length - 1)
            _direction = false;
        else if (_currentPoint == 0) 
            _direction = true;
        switch (_direction)
        {
            case (true):
                _currentPoint++;
                break;
            case (false):
                _currentPoint--;
                break;
        }
    }

}
