using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    private CharacterController _characterController;
    private Player _player;
    private Vector3 _moveVector;
    private Vector3 _gravityForce;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!_player.GameOver)
        {
            CharacterControllerMove();
            CharacterControllerGravity();
        }
        else _characterController.Move(Vector3.zero);
    }

    private void CharacterControllerMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxisRaw("Horizontal") * _speed;
        _moveVector.z = Input.GetAxisRaw("Vertical") * _speed;
        _moveVector.y = _gravityForce.y;

        Vector3 localDirection = transform.right * _moveVector.x + transform.forward * _moveVector.z + transform.up * _moveVector.y;
        _characterController.Move(localDirection * Time.deltaTime);     
    }
    private void CharacterControllerGravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce.y -= 25f * Time.deltaTime;
        }
        else _gravityForce.y = -1f;
        /*if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _gravityForce.y = _jumpPower;
        }*/
    }
}
