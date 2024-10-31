using UnityEngine;
using UnityEngine.Assertions;

public class HurtBox : MonoBehaviour
{
    [SerializeField] EntityHealth _Health;

    private void Awake()
    {
        _Health.OnDeathAction += _stopHitZone;
    }

    public void TakeDamage(int value)
    {
        if(!_Health.IsAlive) throw new AssertionException("Player Dead", "HitZone");
        if (value <= 0) throw new AssertionException("Damage value must be greater than 0", "HitZone");
        _Health.TakeDamage(value);
    }

    private void _stopHitZone()
    {
        GetComponent<Collider>().enabled = false;
    }
}
