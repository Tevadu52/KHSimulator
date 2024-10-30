using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] int _goldValue;

    public override void Use(PickUpItem pui)
    {
        pui.EntityGold.AddGold(_goldValue);
        base.Use(pui);
    }

}
