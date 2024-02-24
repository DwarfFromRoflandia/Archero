using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScanProjectile : Projectile
{
    protected override void OnTargetCollision(Collision collision, Player player)
    {
        //player.ApplyDamage(Damage);
        Debug.Log($"player have type {player.GetType()}");
    }
}
