using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField, Required] Animator _animator;

    [SerializeField, Required] PlayerMove _move;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _isWalkingBoolParam = "Walking";
    }


    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

}
