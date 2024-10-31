using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField, Required] Animator _animator;

    [SerializeField, Required] PlayerMove _move;
    [SerializeField, Required] PlayerAttack _attack;
    [SerializeField, Required] EntityHealth _health;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam, _deadBoolParam;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] string _getHitTriggerParam, _attackTriggerParam;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _health = GetComponent<EntityHealth>();
        _isWalkingBoolParam = "Walking";
        _deadBoolParam = "Dead";
        _getHitTriggerParam = "GetHit";
        _getHitTriggerParam = "Attack";
    }


    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;
        _health.OnHitAction += _getHit;
        _health.OnDeathAction += _die;
        _attack.OnAttack += _attack_Attack;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }
    private void _die()
    {
        _getHit();
        _animator.SetBool(_deadBoolParam, true);
    }
    private void _getHit()
    {
        _animator.SetTrigger(_getHitTriggerParam);
    }

    private void _attack_Attack()
    {
        _animator.SetTrigger(_attackTriggerParam);
    }
}
