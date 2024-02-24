using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyMovement : IMovable
{
    private Transform _player;
    private EnemyVision _enemyVision;
    public GroundEnemyMovement(Player player, EnemyVision enemyVision)
    {
        _player = player.transform;
        _enemyVision = enemyVision;
        Debug.Log(_enemyVision.GetType());
    }

    public void Move(NavMeshAgent navMeshAgent, Transform transform)
    {
        if (_enemyVision.IsSeeTarget && !_enemyVision.IsAttackTarget)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(_player.position);
            transform.LookAt(_player);
            Debug.Log("I Move");
        }
        else if (_enemyVision.IsSeeTarget && _enemyVision.IsAttackTarget)
        {
            navMeshAgent.isStopped = true;
            transform.LookAt(_player);
            Debug.Log("I Attack");
        }
    }
}
