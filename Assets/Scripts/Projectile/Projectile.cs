using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ProjectileDisposeType _disposeType;

    private bool _isProjectileDisposed; //поле, проверяющее был ли снаряд уничтожен или нет

    public float Damage => _damage;
    public Rigidbody Rigidbody => _rigidbody;
    public ProjectileDisposeType DisposeType => _disposeType;
    public bool IsProjectileDisposed => _isProjectileDisposed;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isProjectileDisposed) return; //если снаряд был уничтожен - выходим из метода

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnTargetCollision(collision, player);

            if (ProjectileDisposeType.OnTargetCollision == _disposeType)
            {
                DisposeProjectile();
            }
        }
        else
        {
            OnOtherCollision(collision);
        }

        OnAnyCollision(collision);

        if (ProjectileDisposeType.OnAnyCollision == _disposeType) DisposeProjectile();
    }

    public void DisposeProjectile()
    {
        Destroy(gameObject);
        _isProjectileDisposed = true;
    }

    protected virtual void OnTargetCollision(Collision collision, Player player) { }
    protected virtual void OnOtherCollision(Collision collision) { }
    protected virtual void OnAnyCollision(Collision collision) { }
}
