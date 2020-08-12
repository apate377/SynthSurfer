using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseView;
    public GameObject OptionsView;
    public GameObject InstructionsView;
    public GameObject Box1, Box2;
    //private Animator animator;
    //private bool expanded = false;

    void Start() {
        /*
        animator = Box.GetComponent<Animator>();
        animator.Play("IdleNormal");
        */
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

    }

    public void Pause() {
        if (GameIsPaused) {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        } else {
            gameObject.SetActive(true);
            PauseView.SetActive(true);
            OptionsView.SetActive(false);
            InstructionsView.SetActive(false);
            Box1.SetActive(true);
            Box2.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void Options() {
        PauseView.SetActive(false);
        OptionsView.SetActive(true);
    }

    public void Back() {
        InstructionsView.SetActive(false);
        OptionsView.SetActive(false);
        PauseView.SetActive(true);
        Box1.SetActive(true);
        Box2.SetActive(false);
    }

    public void HowToPlay() {
        /*if (!expanded) {
            animator.SetBool("Expand", true);
            animator.SetBool("Shrink", false);
        } else {
            animator.SetBool("Shrink", true);
            animator.SetBool("Expand", false);
        } */
        Box1.SetActive(false);
        Box2.SetActive(true);
        PauseView.SetActive(false);
        InstructionsView.SetActive(true);
    }
}
