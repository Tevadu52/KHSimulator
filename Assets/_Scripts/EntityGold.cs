using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.Events;

public class EntityGold : MonoBehaviour
{
    [SerializeField] int _gold;
    public int Gold {  get { return _gold; } }

    public Action<int> OnGoldChange;

    public void AddGold(int value)
    {
        _gold += value;
        OnGoldChange?.Invoke(_gold);
    }

}
