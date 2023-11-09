using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WalkingEnemy : Enemy
{
    private NavMeshAgent _navMeshAgent;
    private Transform _player;
    private float _attackRange;

    public void Initialize(float speed, int damage, int health, Transform player)
    {
        _speed = speed;
        _damage = damage;
        _health = health;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = player;

        _attackRange = 1;
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        _navMeshAgent.SetDestination(_player.position);
    }   
}
