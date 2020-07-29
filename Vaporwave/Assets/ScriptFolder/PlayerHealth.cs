using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] GameObject playerControl;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void OnTriggerEnter(Collider collider){
        TakeDamage(5);
  }

    void TakeDamage(int damage){
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
      if (currentHealth <= 0){
        deathScreen.SetActive(true);
        playerControl.GetComponent<PlayerMovement>().SetPlayerEnabled(false);
      }
    }
}
