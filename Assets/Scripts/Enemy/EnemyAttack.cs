using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField, Min(0f)] private float _force;

    private EnemyVision _enemyVision;

    private void Start()
    {
        _enemyVision = GetComponent<EnemyVision>();
    }

    private void Attack()
    {
        var projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);

        projectile.Rigidbody.AddForce(_projectileSpawnPoint.forward * _force, _forceMode);
    }
}
