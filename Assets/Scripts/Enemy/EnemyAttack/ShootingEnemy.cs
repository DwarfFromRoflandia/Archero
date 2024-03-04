using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShootingEnemy : MonoBehaviour, IAttacker
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField, Min(0f)] private float _force;

    [SerializeField, Min(0f)] private float _rateOfFire;
    private float _timeToReload;

    public void Attack()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_timeToReload <= 0)
        {
            var projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
            projectile.Rigidbody.AddForce(_projectileSpawnPoint.forward * _force, _forceMode);
            _timeToReload = _rateOfFire;
        }
        else
        {
            _timeToReload -= Time.deltaTime;
        }
    }
}
