using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _damage;

    public int Health { get; private set; }

    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {

    }
}
