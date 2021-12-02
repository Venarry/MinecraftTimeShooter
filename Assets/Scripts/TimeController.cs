using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _slowSpeed;

    private CharacterController _characterController;
    private bool _forcedAcceleration;
    private bool _isStarted;

    private void Start()
    {
        _characterController = GetComponentInParent<CharacterController>();
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = _slowSpeed * 0.02f;
    }
    private void Update()
    {
        if (_isStarted)
            VelocityCheck();
        else Time.timeScale = 0;
        if (Input.anyKey || _forcedAcceleration)
        {
            _isStarted = true;
        }
    }
    private void VelocityCheck()
    {
        if (_characterController.velocity != Vector3.zero || _forcedAcceleration)
        {
            Time.timeScale = _normalSpeed;
        }
        else
        {
            Time.timeScale = _slowSpeed;
        }
    }

    public IEnumerator ForcedAcceleration()
    {
        _forcedAcceleration = true;
        yield return new WaitForSeconds(0.03f);
        _forcedAcceleration = false;
    }
}
