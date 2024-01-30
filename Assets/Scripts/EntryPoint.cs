using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EntryPoint : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;

    [Inject]
    public void Construct(Player player, PlayerMovement playerMovement)
    {
        _player = player;
        _playerMovement = playerMovement;
    }

    private void Start()
    {
        _player.Initialize(new KeyboardController(_playerMovement));
    }

}
