using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocalInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private Projectile _projectilePrefab;

    /*It sounds like you need to sort out the 'Unable to resolve type' errors. 
     * That means that injection is happening but zenject can't find bindings for all the [Inject] data in the MonoBehaviours
     */
    public override void InstallBindings()
    {
        BindPlayer();
        BindProjectile();
        BindEnemyAttck();
    }
    
    private void BindEnemyAttck()
    {
        Container
            .Bind()
            .FromInstance(_enemyAttack)
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container
            .Bind()
            .FromInstance(_player)
            .AsSingle();
    }

    private void BindProjectile()
    {

    }
}
