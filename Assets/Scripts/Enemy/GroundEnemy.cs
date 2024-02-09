using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;


public class GroundEnemy : Enemy
{
    private NavMeshAgent _navMeshAgent;

    [Inject]
    private void Construct(Player player, IMovable movable)
    {
        _player = player;
        StartCoroutine(Coroutine());

        _movable = movable;
        Debug.Log(_movable.GetType());

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isSeeTarget)
        {
            _movable.Move(_navMeshAgent);
        }

    }

}
