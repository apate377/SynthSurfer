using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyToText : MonoBehaviour
{
    TextMeshProUGUI text;
    MoneyStorage moneyStorage;

    void Start()
    {
      text = GetComponent<TextMeshProUGUI>();
      moneyStorage = FindObjectOfType<MoneyStorage>();
      text.text = moneyStorage.GetMoney().ToString();
    }

    void Update(){
      text.text = moneyStorage.GetMoney().ToString();
    }
}
