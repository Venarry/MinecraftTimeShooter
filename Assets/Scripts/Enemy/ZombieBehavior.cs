using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieBehavior : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Player _player;
    private Animator _animator;
    private RandomiseDestination _randomiseDestination;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _randomiseDestination = GetComponent<RandomiseDestination>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 1.3f)
        {
            _agent.enabled = false;
            _animator.SetBool("Attack", true);
            StartCoroutine(PlayerHit());
        }
        else
        {
            _agent.enabled = true;
            _agent.SetDestination(_randomiseDestination.targetPoint);

        }
    }
    private IEnumerator PlayerHit()
    {
        yield return new WaitForSeconds(0.3f);
        _player.Lose();
    }
    /*private IEnumerator SetTargetPoint()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) > _agrDistance)
        {
            CheckPointDistance();          
        }
        else targetPoint = _player.transform.position;
        
        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(SetTargetPoint());
    }
    private void CheckPointDistance()
    {
        if(Vector3.Distance(targetPoint, _player.transform.position) > _agrDistance)
        {
            targetPoint = SetRandomPoint();
        }
    }
    private Vector3 SetRandomPoint()
    {
        return new Vector3(_player.transform.position.x + Random.Range(-_agrDistance, _agrDistance), _player.transform.position.y, _player.transform.position.z + Random.Range(-_agrDistance, _agrDistance));
    }*/
}
