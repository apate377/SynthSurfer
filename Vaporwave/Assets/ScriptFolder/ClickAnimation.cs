using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ClickAnimation : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform mousePos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")){
          transform.position = mousePos.position;
          animator.SetTrigger("Click");
        }
    }
}
