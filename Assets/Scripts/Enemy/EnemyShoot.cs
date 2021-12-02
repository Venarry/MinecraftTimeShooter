using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ViewChecker))]
public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _coolDown;
    [SerializeField] private Arrow _bullet;
    [SerializeField] private Transform _shootPoint;
    private ViewChecker _viewChecker;

    private void Start()
    {
        StartCoroutine(ShootTimer());
        _viewChecker = GetComponent<ViewChecker>();
    }

    private IEnumerator ShootTimer()
    {       
        yield return new WaitForSeconds(Random.Range(_coolDown-0.5f,_coolDown+0.5f));
        if (_viewChecker.IsView())
            Shoot();
        StartCoroutine(ShootTimer());
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, _shootPoint.transform.rotation);
    }
}
