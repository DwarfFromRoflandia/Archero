using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IMoveble
{
    protected float _speed;

    protected int _damage;
    protected int _health;



    public void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }


    public void TakeDamage(int damage)
    {

    }


    public abstract void Move();

}
