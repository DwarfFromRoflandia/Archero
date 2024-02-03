using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GroundEnemy : Enemy
{
    [Inject]
    private void Construct(Player player)
    {
        _player = player;
        StartCoroutine(Coroutine());
    }
}
