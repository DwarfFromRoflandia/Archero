using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private float _attackRadius;

    private bool _isAttackTarget;

    private Transform _target;    
    public float AttackRadius  => _attackRadius; 
    public bool IsAttackTarget => _isAttackTarget; 
    public Transform Target => _target;

    public IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            FieldOfAttack();
        }
    }

    private void FieldOfAttack()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _attackRadius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            _target = rangeChecks[0].transform;

            for (int i = 1; i < rangeChecks.Length; i++)
            {
                if (Vector3.Distance(transform.position, rangeChecks[i].transform.position) < Vector3.Distance(transform.position, _target.position))
                {
                    _target = rangeChecks[i].transform;
                }
            }

            Vector3 directionToTarget = (_target.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, _target.position);

            if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _targetMask))
            {
                _isAttackTarget = true;
            }
            else
            {
                _isAttackTarget = false;
            }
        }
        else if (_isAttackTarget)
        {
            _isAttackTarget = false;
        }
    }
}
