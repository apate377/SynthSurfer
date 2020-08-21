using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    //Try PlayerPref instead
    public static bool dualWielded = false;

    public GameObject DualWieldEquipped;

    public void DualWield() {
        if (!dualWielded && MoneyStorage.GetUpgradePath("Wield") == 1) {
            dualWielded = true;
            DualWieldEquipped.SetActive(true);
        } else {
            dualWielded = false;
            DualWieldEquipped.SetActive(false);
        }
        if(MoneyStorage.GetMoney() >= 200 && MoneyStorage.GetUpgradePath("Wield") == 0) {
            MoneyStorage.MoneyLoss(200);
            MoneyStorage.SetUpgradePath("Wield");
            dualWielded = true;
            DualWieldEquipped.SetActive(true);
        }
    }
}
