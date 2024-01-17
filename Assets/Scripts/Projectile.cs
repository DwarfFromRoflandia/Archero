using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _transformPlayer;
    private Vector3 _target;

    public void Initialize(Transform transformPlayer)
    {
        _transformPlayer = transformPlayer;
        _target = new Vector3(_transformPlayer.position.x, _transformPlayer.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _transformPlayer.position, _speed * Time.deltaTime);
       
    }
}
