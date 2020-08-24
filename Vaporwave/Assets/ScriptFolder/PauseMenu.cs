using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseView;
    public GameObject OptionsView;
    public GameObject InstructionsView;
    public GameObject Box;
    private Animator animator;
    private float transitionTime = 0.5f;

    void Start() {
        animator = Box.GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
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
            //Box1.SetActive(true);
            //Box2.SetActive(false);
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

        animator.SetBool("Shrink", true);
        animator.SetBool("Expand", false);
    }

    public void HowToPlay() {
        PauseView.SetActive(false);
        StartCoroutine(ShowInstructions());

        animator.SetBool("Expand", true);
        animator.SetBool("Shrink", false);
    }

    IEnumerator ShowInstructions() {
        yield return new WaitForSecondsRealtime(transitionTime);
        InstructionsView.SetActive(true);
    }
}
