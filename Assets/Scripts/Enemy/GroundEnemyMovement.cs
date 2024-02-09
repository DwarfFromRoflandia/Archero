using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyMovement : IMovable
{
    private Transform _player;
    public GroundEnemyMovement(Player player)
    {
        _player = player.transform;
    }

    public void Move(NavMeshAgent navMeshAgent)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(_player.position);
    }
}
