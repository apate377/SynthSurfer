using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerDamage : MonoBehaviour
{
    [SerializeField] FryerHealth fryerHealth;

    void OnTriggerEnter(Collider collider){
      fryerHealth.CollisionMessage();
    }

}
