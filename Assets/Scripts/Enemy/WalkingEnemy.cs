using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;
using Zenject;


public class WalkingEnemy : Enemy
{
    [SerializeField] private LayerMask _layerMask;
    private NavMeshAgent _navMeshAgent;
    private Transform _playerPosition;
    private float _attackRange;
    private IMoveble _moveble;
    private Player _player;


    public void Initialize(Player player)
    {
        _speed = 2f;
        _damage = 0;
        _health = 0;
        _attackRange = 1;
        
        _enemyAttack = GetComponent<EnemyAttack>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _player = player;
        _playerPosition = player.transform;

        _moveble = new MovementForRangedCombat(_navMeshAgent, _playerPosition);
        //_moveble = moveble;
        Debug.Log(_moveble.GetType());
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
