using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    private bool _isSeeTarget;
    private bool _isAttackTarget;


    [SerializeField] private float _visibilityRadius;
    [SerializeField] private float _attackRadius;

    [Range(0, 360)]
    [SerializeField] private float _angle;
    [SerializeField] private Player _player;
    public float VisibilityRadius { get => _visibilityRadius; }
    public float AttackRadius { get => _attackRadius; }
    public bool IsSeeTarget { get => _isSeeTarget; }
    public bool IsAttackTarget { get => _isAttackTarget;}

    public float Angle { get => _angle; }

    public Player Player { get => _player; }


    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    public IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            FieldOfVision();
            FieldOfAttack();
        }
    }

    private void FieldOfVision()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _visibilityRadius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform; // берём трансформ игрока. Т.к. он единственный будет в массиве, трансформ берём у индекса 0.

            Vector3 directionToTarget = (target.position - transform.position).normalized; // normalized приравнивает значение от 0 до 1

            if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                {
                    // see player
                    _isSeeTarget = true;
                }
                else
                {
                    // don't see player
                    _isSeeTarget = false;
                }
            }
            else
            {
                // there may be an error if the length of the array is 0. Exclude this here
                _isSeeTarget = false;
            }
        }
        else if (_isSeeTarget)
        {
            _isSeeTarget = false;
        }
    }

    private void FieldOfAttack()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _attackRadius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _targetMask))
            {
                Debug.Log("I attack target");
                _isAttackTarget = true;
            }
            else
            {
                _isAttackTarget = false;
            }
        }
        else if (_isSeeTarget)
        {
            _isAttackTarget = false;
        }
    }
}
