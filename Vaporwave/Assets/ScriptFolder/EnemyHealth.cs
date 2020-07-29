﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth = 60;
    private int currentHealth;
    [SerializeField] EnemyHealthBar health;
    [SerializeField] int moneyValue = 10;
    MoneyStorage moneyStorage;
    EnemyCount EnemyCount;

    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        moneyStorage = FindObjectOfType<MoneyStorage>();
        EnemyCount = transform.parent.gameObject.GetComponent<EnemyCount>();
    }
    void Update(){
      if (currentHealth ==0){
        moneyStorage.MoneyHit(moneyValue);
        EnemyCount.DecrementCount();
        Destroy(gameObject);
      }
      
    }

    void OnTriggerEnter(Collider collider){
        TakeDamage(20);
  }

    void TakeDamage(int damage){
      currentHealth -= damage;
      health.SetHealth(currentHealth);
    }
}
