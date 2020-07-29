using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BPMMeter : MonoBehaviour
{
    private int maxHealth = 15;
    private int currentHealth;
    public HealthBar healthBar;
    private bool alwaysTrue = true;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] GameObject playerControl;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(Regenerate());
    }

    void Update(){
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !BPSTiming.getCanShoot()){
          //play eheh sound
          TakeDamage(1);
        }
    }

    IEnumerator Regenerate(){
        if (currentHealth < maxHealth){
          currentHealth += 1;
          healthBar.SetHealth(currentHealth);
        }
        yield return new WaitForSeconds(BPSTiming.getSPB()*3);
        StartCoroutine(Regenerate());
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
