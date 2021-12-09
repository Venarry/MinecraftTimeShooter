using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ViewChecker))]
[RequireComponent(typeof(NavMeshAgent))]
public class SkeletonBehavior : MonoBehaviour
{
    private ViewChecker _viewChecker;
    private NavMeshAgent _agent;
    private Player _player;
    private Animator _animator;
    private RandomiseDestination _randomiseDestination;
    Vector3 targetPoint;

    private void Start()
    {
        _viewChecker = GetComponent<ViewChecker>();
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _randomiseDestination = GetComponent<RandomiseDestination>();
        _agent.SetDestination(_randomiseDestination.targetPoint);
    }

    private void Update()
    {       
        if (!_viewChecker.IsView())
        {
            _agent.SetDestination(_randomiseDestination.targetPoint);
        }

        if(Vector3.Distance(_agent.destination, transform.position) > 1f)
        {
            _animator.SetBool("Walk", true);
        }
        else _animator.SetBool("Walk", false);
    }
}
