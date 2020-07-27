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
      StartCoroutine(LoadLevel());
    }

    public void OpenOptions() {
      gameObject.SetActive(false);
      OptionsMenu.SetActive(true);
    }

    IEnumerator LoadLevel() {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(transitionTime);
      asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
      Application.Quit();
      Debug.Log("QUIT!");
    }

}
