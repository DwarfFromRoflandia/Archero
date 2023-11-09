using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;


public class WalkingEnemy : Enemy
{
    [SerializeField] private LayerMask _layerMask;
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
        
        if (IsVisibility())
        {
            //attack is called here
            Debug.Log("Attacked");
            _navMeshAgent.isStopped = true;
        }
        else
        {
            Move();
        }
    }

    public bool IsVisibility()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask);
    }

    public override void Move()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(_player.position);
    }   
}
