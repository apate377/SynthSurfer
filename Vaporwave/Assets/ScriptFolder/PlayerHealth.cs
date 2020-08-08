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

    void OnTriggerEnter(Collider collider) {
        // The layer for the health pack prefab is "PostProcessing" but it
        // should be "HealthPack." However, when I change the layer, the health
        // pack prefab disappears.
        if (collider.gameObject.layer == LayerMask.NameToLayer("PostProcessing")) {
            AddHealth(25);
            Destroy(collider.gameObject);
        } else {
            TakeDamage(5);
        }
  }

    void TakeDamage(int damage){
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
      if (currentHealth <= 0){
        deathScreen.SetActive(true);
        playerControl.GetComponent<PlayerMovement>().SetPlayerEnabled(false);
      }
    }

    void AddHealth(int health) {
        print("added health");
        currentHealth += health;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
