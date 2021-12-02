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

    private void Start()
    {
        _viewChecker = GetComponent<ViewChecker>();
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_viewChecker.IsView())
        {
            _agent.enabled = true;
            _agent.SetDestination(_player.transform.position);
            _animator.SetBool("Walk", true);
        }
        else
        {
            _agent.enabled = false;
            _animator.SetBool("Walk", false);
        }
    }
}
