using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using System;

public class GroundEnemy : Enemy
{
    private NavMeshAgent _navMeshAgent;
    private EnemyVision _enemyVision;

    public Action OnAttackStarted;
    public Action OnAttackEnded;

    [Inject]
    private void Construct(IMovable movable, IAttacker attacker)
    {
        _enemyVision = GetComponent<EnemyVision>();
        StartCoroutine(_enemyVision.Coroutine());

        _movable = movable;
        Debug.Log(_movable.GetType());

        _attacker = attacker;
        Debug.Log(_attacker.GetType());

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }

    private void FixedUpdate()
    {
        _movable.Move(_navMeshAgent, gameObject.transform);
    }

    private void Update()
    {
        if (_enemyVision.IsSeeTarget && _enemyVision.IsAttackTarget) PerformAttack();
    }
}
