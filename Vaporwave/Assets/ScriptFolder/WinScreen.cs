using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private string genre;
    [SerializeField] private int level;


    void Start()
    {
    }

    public void Check(){
      if (MoneyStorage.GetSongPack(genre) +1 == level) {
        MoneyStorage.SetSongPack(genre);
        print("Increment " + genre + " to " + MoneyStorage.GetSongPack(genre));
      }
    }
}
