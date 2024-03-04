using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Player : MonoBehaviour, IDamageable
{
    private int _damage;

    public int Health { get; private set; }

    private IController _controller;

    public void Initialize(IController controller)
    {
        _controller = controller;
        Debug.Log(_controller.GetType());
    }

    private void FixedUpdate()
    {
        Move();
    }

    //public void Attack(Enemy enemy)
    //{
    //    enemy.TakeDamage(_damage);
    //}

    private void Move()
    {
        _controller.Controller();
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
