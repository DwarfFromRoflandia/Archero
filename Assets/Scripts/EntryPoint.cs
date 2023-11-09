using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WalkingEnemy _walkingEnemy;

    [SerializeField] private JoystickMovement _joystickMovement;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EnemyAttack _enemyAttack;
    private void Start()
    {
        _joystickMovement.Initialize();
        _playerMovement.Initialize();


        _walkingEnemy.Initialize(2, 0, 0, _player.transform, _player);
        _enemyAttack.Initialize(_player.transform);
    }

}
