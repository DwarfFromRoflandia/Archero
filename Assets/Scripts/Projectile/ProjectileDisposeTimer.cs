using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDisposeTimer : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _countDown;

    private Projectile _projectile;
    private float _elapsedTime;

    private void Start()
    {
        _projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        if (_projectile.IsProjectileDisposed) return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _countDown) _projectile.DisposeProjectile();
    }
}
