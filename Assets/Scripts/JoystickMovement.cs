using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : Joystick, IControllable
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        Controller();
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
