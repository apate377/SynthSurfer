using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPSBlink : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    void Update()
    {
        if (BPSTiming.getCanShoot()){
           gameObject.SetActive(true);
        }else {
          gameObject.SetActive(false);
        }
    }
}
