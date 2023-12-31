using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class JoystickMovement : Joystick, IController
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        Controller();
        Debug.Log(Controller());
    }

    public bool Controller()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _playerMovement.MovePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
            _playerMovement.RoatatePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
            return true;
        }
        else
        {
            return false;
        }
    }
}
