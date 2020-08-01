using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtons : MonoBehaviour
{
    [SerializeField] string genre;
    [SerializeField] GameObject[] levels;

    void Start()
    {
        for (int i = 0; i <= MoneyStorage.GetSongPack(genre) ; i++){
            levels[i].SetActive(true);
        }
    }
}
