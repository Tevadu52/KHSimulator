using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpItem : MonoBehaviour
{
    [SerializeField] EntityGold _entityGold;
    public EntityGold EntityGold { get { return _entityGold; } }
    [SerializeField] EntityHealth _entityHealth;
    public EntityHealth EntityHealth { get { return _entityHealth; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item item))
        {
            item.Use(this);
        }
    }



}
