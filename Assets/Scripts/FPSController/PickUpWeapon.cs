using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[ExecuteAlways]
public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;

    private Camera _camera;
    private PlayerShoot _playerShoot;
    private TimeController _timeController;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _timeController = FindObjectOfType<TimeController>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 3, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward,out hit, 3))
            if(hit.collider.gameObject.TryGetComponent(out Weapon _weapon) && Input.GetMouseButtonDown(0) && _weaponPoint.GetComponentInChildren<Weapon>() == null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.SetParent(_weaponPoint);
                hit.collider.gameObject.transform.DOLocalMove(Vector3.zero, .25f).SetUpdate(true);
                hit.collider.gameObject.transform.DOLocalRotate(new Vector3(0,-90,-25), .25f).SetUpdate(true);
                StartCoroutine(Picked());
            }
    }

    private IEnumerator Picked()
    {
        StartCoroutine(_timeController.ForcedAcceleration());
        yield return new WaitForSeconds(0.01f);
        _playerShoot.WeaponStatus(true);
    }
}
