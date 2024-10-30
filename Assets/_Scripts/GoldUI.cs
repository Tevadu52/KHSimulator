using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textGold;
    [SerializeField] EntityGold _entityGold;

    private void Awake()
    {
        _entityGold.OnGoldChange += _changeGoldText;
    }

    private void Start()
    {
        _changeGoldText(_entityGold.Gold);
    }

    private void _changeGoldText(int value)
    {
        _textGold.text = "Gold : " + value.ToString();
    }
}
