using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;


public class WalkingEnemy : Enemy
{
    [SerializeField] private LayerMask _layerMask;
    private NavMeshAgent _navMeshAgent;
    private Transform _playerPosition;
    private float _attackRange;
    private IMoveble _moveble;
    private Player _player;
    public void Initialize(float speed, int damage, int health, Transform playerPosition, Player player)
    {
        _speed = speed;
        _damage = damage;
        _health = health;
        _enemyAttack = GetComponent<EnemyAttack>();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerPosition = playerPosition;
        _player = player;

        _attackRange = 1;
        _moveble = new MovementForRangedCombat(_navMeshAgent, _playerPosition);

    }

    private void Update()
    { 
        
        if (IsVisibility())
        {
            Attack(_player);
            Debug.Log("Attacked");
            _navMeshAgent.isStopped = true;
        }
        else
        {
            _moveble.Move();
        }
    }

    public bool IsVisibility()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask);
    }
}
