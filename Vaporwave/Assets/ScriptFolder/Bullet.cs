using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public GameObject hitEffect;

  void OnTriggerEnter(Collider collider){
      GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
      Destroy (effect, 5f);
      Destroy(gameObject);
}
  void Start(){
      Destroy (gameObject, 3f);
  }
}
