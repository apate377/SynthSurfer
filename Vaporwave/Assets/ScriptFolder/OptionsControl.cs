using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsControl : MonoBehaviour
{
    private float muteValue = 0.0001f;
    public static float setValue = 1f;
    private bool mute = false;
    private Slider volumeSlider;
    private RawImage CancelImage;

    public GameObject Volume;
    public GameObject MuteSign;
    public GameObject FillArea;
    public GameObject MainMenu;
    public AudioMixer mixer;

    void Start() {
        volumeSlider = Volume.GetComponent<Slider>();
        CancelImage = MuteSign.GetComponent<RawImage>();
        CancelImage.enabled = false;

        volumeSlider.value = setValue;
    }

    void Update () {
        setValue = volumeSlider.value;
    }

    public void MuteVolume() {
        if(mute) { // Unmute
            UnmuteVisual();
            volumeSlider.value = setValue;
        } else { // Mute
            MuteVisual();
            setValue = volumeSlider.value;
            volumeSlider.value = muteValue;
        }

    }

    private void UnmuteVisual() {
        CancelImage.enabled = false;
        FillArea.SetActive(true);
        mute = false;
    }

    private void MuteVisual() {
        CancelImage.enabled = true;
        FillArea.SetActive(false);
        mute = true;
    }


    public void ChangeVolume(float sliderValue) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        if (sliderValue > muteValue) {
            UnmuteVisual();
        } else {
            MuteVisual();
        }
    }

    public void OpenMainMenu() {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }

}
