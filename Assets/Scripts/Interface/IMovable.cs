using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMovable
{
    public void Move(NavMeshAgent navMeshAgent, Transform transform);
}
