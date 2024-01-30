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


    /*It sounds like you need to sort out the 'Unable to resolve type' errors. 
     * That means that injection is happening but zenject can't find bindings for all the [Inject] data in the MonoBehaviours
     */
    public override void InstallBindings()
    {

        BindPlayer();
        BindPlayerMovement();
        BindKeyboardController();
        BindEntryPoint();
    }
    

    private void BindPlayer()
    {
        _playerClone = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);

        Container.Bind<Player>()
            .FromInstance(_playerClone)
            .AsSingle();
    }

    private void BindKeyboardController()
    {
        Container
            .Bind<IController>() 
            .To<KeyboardController>() 
            .AsSingle()
            .NonLazy();
    }

    private void BindPlayerMovement()
    {
        PlayerMovement playerMovement = _playerClone.GetComponent<PlayerMovement>();

        Container
            .Bind<PlayerMovement>()
            .FromInstance(playerMovement)
            .AsSingle()
            .NonLazy();
    }

    private void BindEntryPoint()
    {
        Container
            .Bind<EntryPoint>()
            .FromInstance(_entryPoint)
            .AsSingle();
    }
}