using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;


public class GroundEnemy : Enemy
{
    private NavMeshAgent _navMeshAgent;
    private EnemyVision _enemyVision;

    [Inject]
    private void Construct(IMovable movable)
    {
        _enemyVision = GetComponent<EnemyVision>();
        StartCoroutine(_enemyVision.Coroutine());

        _movable = movable;
        Debug.Log(_movable.GetType());

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }

    private void FixedUpdate()
    {
        _movable.Move(_navMeshAgent, gameObject.transform);
    }
}
