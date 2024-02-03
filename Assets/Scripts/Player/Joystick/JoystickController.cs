using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class JoystickController : Joystick, IController
{
    private PlayerMovement _playerMovement;

    [Inject]
    private void Construct(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }


    public void Controller()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _playerMovement.MovePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
            _playerMovement.RoatatePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
    }
}
