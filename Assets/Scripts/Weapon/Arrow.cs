using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private TrailRenderer _trail;
    private Player _player;
    private ArenaScore _score;
    private float _lifeTime;

    private void Start()
    {
        _score = FindObjectOfType<ArenaScore>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= 10) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Head head))
        {
            other.GetComponentInParent<Enemy>().GetHit(true);
            ParentInObject(other);
            SpawnParticle();
            if (_score != null)
            {
                _score.GetScore(10);
            }
        }
        if (other.gameObject.TryGetComponent(out Body body))
        {
            other.GetComponentInParent<Enemy>().GetHit(false);
            ParentInObject(other);          
            SpawnParticle();
            if (_score != null)
            {
                _score.GetScore(5);
            }
        }
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            ParentInObject(other);
        }
        if (other.gameObject.TryGetComponent(out Glass glass))
        {
            Destroy(gameObject);
            Destroy(glass.gameObject);
            SpawnParticle();
        }
        if (other.gameObject.TryGetComponent(out _player) && !_isPlayer)
        {
            _player.Lose();
            Destroy(gameObject);
        }
        
    }
    private void ParentInObject(Collider other)
    {       
        transform.SetParent(other.gameObject.transform);
        _trail.enabled = false;
        Destroy(this);
        gameObject.AddComponent<TempObject>();
    }
    private void SpawnParticle()
    {
        ParticleSystem currentParticle = Instantiate(_explosionEffect, transform.position, transform.rotation);
        currentParticle.gameObject.SetActive(true);
    }
}
