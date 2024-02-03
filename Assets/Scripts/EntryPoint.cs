using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private JoystickController _joystickController;
    private Player _player;
    private PlayerMovement _playerMovement;
    
    [Inject]
    private void Construct(Player player, PlayerMovement playerMovement)
    {
        _player = player;
        _playerMovement = playerMovement;
    }

    private void Start()
    {
        SetController();
    }

    private void SetController()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _joystickController.Initialize();
            _player.Initialize(_joystickController);
        }
        else
        {
            _player.Initialize(new KeyboardController(_playerMovement));
        }
    }
}
