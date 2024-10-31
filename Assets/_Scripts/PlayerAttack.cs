using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;
    [SerializeField] GameObject _attackRange;
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
        OnAttack.Invoke();
        StartCoroutine(AttackCor());
        IEnumerator AttackCor()
        {
            _attackRange.SetActive(true);
            yield return new WaitForSeconds(.2f);
            _attackRange.SetActive(false);
        }
    }

    private void StopAttackInput()
    {
        _attack.action.started -= StartAttack;
    }
}
