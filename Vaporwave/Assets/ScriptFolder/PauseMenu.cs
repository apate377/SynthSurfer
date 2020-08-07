using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseView;
    public GameObject OptionsView;

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
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void Options() {
        PauseView.SetActive(false);
        OptionsView.SetActive(true);
    }

    public void Back() {
        PauseView.SetActive(true);
        OptionsView.SetActive(false);
    }
}
