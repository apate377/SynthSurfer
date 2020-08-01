using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyToText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
      text = GetComponent<TextMeshProUGUI>();
      text.text = MoneyStorage.GetMoney().ToString();
    }

    void Update(){
      text.text = MoneyStorage.GetMoney().ToString();
    }
}
