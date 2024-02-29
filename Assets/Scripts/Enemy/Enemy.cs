using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _healthPoint;
    [SerializeField] protected float _attackSpeed;

    protected IMovable _movable;
    protected IAttacker _attacker;

    protected virtual void TakeDammage()
    {

    }

    protected virtual void PerformAttack() 
    {
        _attacker.Attack();
    }
}
