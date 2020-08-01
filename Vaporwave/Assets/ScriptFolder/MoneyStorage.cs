using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    private static MoneyStorage storageUnit;
    static int money;
    static Dictionary<string, int> SongPack = new Dictionary<string, int>();
    static Dictionary<string, int> UpgradePath = new Dictionary<string, int>();
    bool initialize = false;

    void Awake() {
      if(storageUnit != null && storageUnit != this){
        Destroy(this.gameObject);
      } else {
        storageUnit = this;
        DontDestroyOnLoad(this.gameObject);
      }
    }

    void Start() {
      if (!initialize){
        SongPack["R&B"] = 0;
        SongPack["Dance"] = 0;
        SongPack["Alt"] = 0;
        SongPack["Pop"] = 0;
        SongPack["Hiphop"] = 0;

        UpgradePath["Health"] = 0;
        UpgradePath["Wield"] = 0;
        UpgradePath["Shield"] = 0;
        UpgradePath["Shockwave"] = 0;
        initialize = true;
      }
      string RB = "R&B";
      print("current index of R&B is " + SongPack[RB]);
    }

    public static void MoneyHit(int moneyValue){
      money += moneyValue;
    }

    //getters
    public static float GetMoney(){
      return money;
    }
    public static int GetSongPack(string genre){
      return SongPack[genre];
    }

    public static void SetSongPack(string genre) {
        SongPack[genre]++;
    }

    public static int GetUpgradePath(string category){
      return UpgradePath[category];
    }

    public static void SetUpgradePath(string category) {
        UpgradePath[category]++;
    }

}
