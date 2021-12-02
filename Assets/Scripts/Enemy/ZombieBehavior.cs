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

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
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
            _agent.SetDestination(_player.transform.position);

        }
    }
    private IEnumerator PlayerHit()
    {
        yield return new WaitForSeconds(0.3f);
        _player.Lose();
    }
}
