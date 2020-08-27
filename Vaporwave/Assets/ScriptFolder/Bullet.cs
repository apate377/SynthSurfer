using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public GameObject hitEffect;

  void OnTriggerEnter(Collider collider){
      if(collider.gameObject.layer == LayerMask.NameToLayer("Enemy") || collider.gameObject.layer == LayerMask.NameToLayer("Building")) {
          GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
          Destroy(effect, 5f);
          Destroy(gameObject);
      }
}
  void Start(){
      Destroy(gameObject, 3f);
  }
}
