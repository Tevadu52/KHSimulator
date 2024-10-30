using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    public int MaxHealth {  get { return _maxHealth; } }
    public int CurrentHealth { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public Action<int> OnHealthChange;
    public Action<int> OnHealthMaxChange;
    public Action OnHitAction;
    public Action OnDeathAction;
    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void Heal(int value)
    {
        if (value <= 0) throw new AssertionException("Heal value must be greater than 0", "EntityHealth");
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, _maxHealth);
        OnHealthChange?.Invoke(CurrentHealth);
    }
    public void PowerUp(int value)
    {
        if (value <= 0) throw new AssertionException("PowerUp value must be greater than 0", "EntityHealth");
        _maxHealth += value;
        OnHealthMaxChange?.Invoke(MaxHealth);
    }
    public void TakeDamage(int value)
    {
        if (value <= 0) throw new AssertionException("Damage value must be greater than 0", "EntityHealth");
        CurrentHealth = Mathf.Clamp(CurrentHealth - value, 0, _maxHealth);
        OnHealthChange?.Invoke(CurrentHealth);
        if (CurrentHealth == 0) Die();
        else
        {
            OnHit?.Invoke();
            OnHitAction?.Invoke();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        OnDeathAction?.Invoke();
    }

}
