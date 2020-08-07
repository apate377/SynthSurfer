using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        if (GameIsPaused) {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        } else {
            PauseUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}
