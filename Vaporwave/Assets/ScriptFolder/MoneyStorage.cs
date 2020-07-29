using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    int money;
    Dictionary<string, int> SongPack = new Dictionary<string, int>();
    Dictionary<string, int> UpgradePath = new Dictionary<string, int>();

    void Awake() {
      DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        SongPack["R&B"] = 0;
        SongPack["Dance"] = 0;
        SongPack["Alt"] = 0;
        SongPack["Pop"] = 0;
        SongPack["Hiphop"] = 0;

        UpgradePath["Health"] = 0;
        UpgradePath["Wield"] = 0;
        UpgradePath["Shield"] = 0;
        UpgradePath["Shockwave"] = 0;
    }

    public void MoneyHit(int moneyValue){
      money += moneyValue;
    }

    //getters
    public float GetMoney(){
      return money;
    }
    public int GetSongPack(string genre){
      return SongPack[genre];
    }

    public void SetSongPack(string genre) {
        SongPack[genre]++;
    }

    public int GetUpgradePath(string category){
      return UpgradePath[category];
    }

    public void SetUpgradePath(string category) {
        UpgradePath[category]++;
    }

}
