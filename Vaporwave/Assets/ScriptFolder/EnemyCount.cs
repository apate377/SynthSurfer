using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject winScreen;
    private int count;

    void Start()
    {
        count = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecrementCount() {
        count--;
        if (count == 0) {
            winScreen.SetActive(true);
        }
        print(count);
    }
}
