using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatingEnemy : MonoBehaviour, IAttacker
{
    public void Attack()
    {
        Debug.Log("Attack");
    }
}
