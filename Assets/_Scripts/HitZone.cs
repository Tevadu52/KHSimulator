using UnityEngine;
using UnityEngine.Assertions;

public class HitZone : MonoBehaviour
{
    [SerializeField] EntityHealth _playerHealth;

    private void Awake()
    {
        _playerHealth.OnDeathAction += _stopHitZone;
    }

    public void TakeDamage(int value)
    {
        if(!_playerHealth.IsAlive) throw new AssertionException("Player Dead", "HitZone");
        if (value <= 0) throw new AssertionException("Damage value must be greater than 0", "HitZone");
        _playerHealth.TakeDamage(value);
    }

    private void _stopHitZone()
    {
        GetComponent<Collider>().enabled = false;
    }
}
