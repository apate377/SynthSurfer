using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerHealth : MonoBehaviour
{
    private int maxHealth = 60;
    private int currentHealth;
    [SerializeField] EnemyHealthBar health;
    [SerializeField] int moneyValue = 20;
    EnemyCount EnemyCount;

    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        EnemyCount = transform.parent.gameObject.GetComponent<EnemyCount>();
    }

    public void CollisionMessage(){
      TakeDamage(20);
      if (currentHealth ==0){
        MoneyStorage.MoneyHit(moneyValue);
        EnemyCount.DecrementCount();
        Destroy(gameObject);
      }
    }

    void TakeDamage (int damage){
      currentHealth -= damage;
      health.SetHealth(currentHealth);
    }

}
