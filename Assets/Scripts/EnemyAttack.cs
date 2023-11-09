using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Projectile _prefabProjectile;
    [SerializeField] private Projectile _cloneProjectile;
    private Enemy _enemy;
    private float _timeToReload;
    private Transform _transformPlayer;

    public void Initialize(Transform transformPlayer)
    {
        _transformPlayer = transformPlayer;
        _enemy = GetComponent<Enemy>();
        
    }

    public void Attack()
    {
        if (_timeToReload <= 0)
        {
            _cloneProjectile = Instantiate(_prefabProjectile, transform.position, Quaternion.identity);
            _cloneProjectile.Initialize(_transformPlayer);
            _timeToReload = _enemy.RateOfFire;
            //_cloneProjecttile = instans projectile
        }
        else
        {
            _timeToReload -= Time.deltaTime;
        }

    }
}
