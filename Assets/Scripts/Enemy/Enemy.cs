using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _healthPoint;
    [SerializeField] private float _attackSpeed;

    protected IMovable _movable;
}
