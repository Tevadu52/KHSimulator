using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HurtBox hit))
        {
            hit.TakeDamage(_damage);
        }
    }
}
