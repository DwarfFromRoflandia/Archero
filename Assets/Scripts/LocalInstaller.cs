using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocalInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Player _playerClone;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EntryPoint _entryPoint;
    [SerializeField] private EnemyVision _enemtVision;
    [SerializeField] private ShootingAttack _shootingEnemy;


    /*It sounds like you need to sort out the 'Unable to resolve type' errors. 
     * That means that injection is happening but zenject can't find bindings for all the [Inject] data in the MonoBehaviours
     */
    public override void InstallBindings()
    {
        BindPlayer();
        BindPlayerMovement();
        BindEnemyVision();
        BindGroundEnemyMovement();
        BindShootingEnemy();
    }
    

    private void BindPlayer()
    {
        _playerClone = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);

        Container.Bind<Player>()
            .FromInstance(_playerClone)
            .AsSingle();
    }

    private void BindPlayerMovement()
    {
        _playerMovement = _playerClone.GetComponent<PlayerMovement>();

        Container
            .Bind<PlayerMovement>()
            .FromInstance(_playerMovement)
            .AsSingle()
            .NonLazy();
    }

    private void BindGroundEnemyMovement()
    {
        Container
            .Bind<IMovable>()
            .To<GroundEnemyMovement>()
            .AsSingle()
            .NonLazy();
    }

    private void BindShootingEnemy()
    {
        Container
            .Bind<IAttacker>()
            .To<ShootingAttack>()
            .FromInstance(_shootingEnemy)
            .AsSingle();
    }

    private void BindDetonatingEnemy()
    {
        Container
            .Bind<IAttacker>()
            .To<DetonatingAttack>()
            .AsSingle();
    }

    private void BindEnemyVision()
    {
        Container
            .Bind<EnemyVision>()
            .FromInstance(_enemtVision)
            .AsSingle();
    }
}
