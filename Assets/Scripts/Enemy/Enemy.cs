using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float _speed;

    protected int _damage;
    protected int _health;

    [SerializeField] private float _rateOfFire;
    public float RateOfFire { get => _rateOfFire; }
    protected EnemyAttack _enemyAttack;

    public void Attack(Player player)
    {
        _enemyAttack.Attack();
        player.TakeDamage(_damage);
    }


    public void TakeDamage(int damage)
    {

    }
}
