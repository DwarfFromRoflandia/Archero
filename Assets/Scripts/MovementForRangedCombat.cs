using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementForRangedCombat : IMoveble
{
    private NavMeshAgent _navMeshAgent;
    private Transform _player;
    public MovementForRangedCombat(NavMeshAgent navMeshAgent, Transform player)
    {
        _navMeshAgent = navMeshAgent;
        _player = player;
    }
    public void Move()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(_player.position);
    }
}
