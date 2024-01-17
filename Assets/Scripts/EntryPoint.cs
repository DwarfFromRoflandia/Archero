using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private WalkingEnemy _walkingEnemy;
    [SerializeField] private EnemyAttack _enemyAttack;

    private void Start()
    {
        _player.Initialize(new KeyboardController(_playerMovement));

        _walkingEnemy.Initialize(_player);
        _enemyAttack.Initialize();
    }

}
