using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 moveDirection)
    {
        Vector3 offset = moveDirection * _moveSpeed * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void RoatatePlayer(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}

