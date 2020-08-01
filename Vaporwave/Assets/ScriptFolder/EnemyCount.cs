using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    private int count;
    WinScreen winScript;

    void Start()
    {
        count = gameObject.transform.childCount;
        winScript = winScreen.GetComponent<WinScreen>();
    }

    public void DecrementCount() {
        count--;
        if (count == 0) {
            winScreen.SetActive(true);
            winScript.Check();
        }
        print(count);
    }
}
