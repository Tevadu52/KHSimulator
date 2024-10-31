using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;
    [SerializeField] EntityHealth _playerHealth;

    public event Action OnAttack;


    Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _playerHealth.OnDeathAction += StopAttackInput;
        _attack.action.started += StartAttack;
    }
    private void OnDestroy()
    {
        StopAttackInput();
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {

    }

    private void StopAttackInput()
    {
        _attack.action.started -= StartAttack;
    }
}
