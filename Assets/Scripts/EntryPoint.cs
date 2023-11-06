using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private JoystickMovement _joystickMovement;
    [SerializeField] private PlayerMovement _playerMovement;
    private void Start()
    {
        _joystickMovement.Initialize();
        _playerMovement.Initialize();
    }
}
