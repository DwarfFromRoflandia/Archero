using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardController : IController
{
    private PlayerMovement _playerMovement;

    public KeyboardController(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    public void Controller()
    {
        _playerMovement.MovePlayer(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        _playerMovement.RoatatePlayer(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
