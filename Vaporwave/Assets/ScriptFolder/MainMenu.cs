using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    AsyncOperation asyncOperation;
    [SerializeField] private GameObject OptionsMenu;

    public void PlayGame(){
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void GoBackToMenu(){
      StartCoroutine(LoadLevel(0));
    }
    public void RestartLevel(){
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void OpenOptions() {
      gameObject.SetActive(false);
      OptionsMenu.SetActive(true);
    }

    IEnumerator LoadLevel(int index) {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(transitionTime);
      asyncOperation = SceneManager.LoadSceneAsync(index);
    }

    public void QuitGame(){
      Application.Quit();
      Debug.Log("QUIT!");
    }

}
