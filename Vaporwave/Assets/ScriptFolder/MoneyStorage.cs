using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    int money;

    void Awake(){
      DontDestroyOnLoad(this.gameObject);
    }

    public void MoneyHit(int moneyValue){
      money += moneyValue;
    }

    //getters
    public float GetMoney(){
      return money;
    }
}
