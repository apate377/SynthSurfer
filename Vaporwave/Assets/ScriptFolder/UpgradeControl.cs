using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeControl : MonoBehaviour
{
    public GameObject levelUpgradeMenu;
    public void OpenMainMenu() {
        gameObject.SetActive(false);
        levelUpgradeMenu.SetActive(true);
    }

}
