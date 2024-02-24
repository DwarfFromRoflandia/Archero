using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _isProjectileDisposed; //����, ����������� ��� �� ������ ��������� ��� ���

    public float Damage => _damage;
    public Rigidbody Rigidbody => _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        //if (_isProjectileDisposed) return; //���� ������ ��� ��������� - ������� �� ������

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnTargetCollision(collision, player);
        }
    }

    protected virtual void OnTargetCollision(Collision collision, Player player) { }
}
