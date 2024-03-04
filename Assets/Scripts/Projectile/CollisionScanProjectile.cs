using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScanProjectile : Projectile
{
    protected override void OnTargetCollision(Collision collision, IDamageable damageable)
    {
        //damageable.ApplyDamage(Damage);
        Debug.Log($"player have type {damageable.GetType()}");
    }
}
