using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomiseDestination : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPoint;

    [SerializeField] private float _agrDistance;

    private Player _player;
    private NavMeshAgent _agent;
    private NavMeshPath _agentStatus;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _agent = GetComponent<NavMeshAgent>();
        _agentStatus = new NavMeshPath();
        targetPoint = SetRandomPoint();
        StartCoroutine(SetTargetPoint());
    }
    private void Update()
    {
        Debug.DrawLine(transform.position, targetPoint);
    }
    private IEnumerator SetTargetPoint()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) > _agrDistance)
        {
            CheckPointDistance();
        }
        else targetPoint = _player.transform.position;

        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(SetTargetPoint());
    }
    private void CheckPointDistance()
    {
        if (Vector3.Distance(targetPoint, _player.transform.position) > _agrDistance)
        {
            targetPoint = SetRandomPoint();
        }
    }
    public Vector3 SetRandomPoint()
    {
        Vector3 randomPoint = new Vector3(_player.transform.position.x + Random.Range(-_agrDistance, _agrDistance), _player.transform.position.y, _player.transform.position.z + Random.Range(-_agrDistance, _agrDistance));
        if(_agent.enabled == true)
            _agent.CalculatePath(randomPoint, _agentStatus);
        if (_agentStatus.status == NavMeshPathStatus.PathComplete)
        {
            return randomPoint;
        }
        else
        {
            return _player.transform.position;
        }
    }
}
