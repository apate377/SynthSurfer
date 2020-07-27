using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private float intensity;
    ChromaticAberration chromaticAberrationLayer = null;
     [SerializeField] GameObject renderBox;
    public bool isHealthBar;

    void Start(){
       if (isHealthBar){
         PostProcessVolume volume = renderBox.GetComponent<PostProcessVolume>();
         volume.profile.TryGetSettings(out chromaticAberrationLayer);
       }
    }
    void Update(){

    }

    public void SetMaxHealth(int health){
      slider.maxValue = health;
      slider.value = health;

      fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health){
      slider.value = health;
     if (isHealthBar){
         chromaticAberrationLayer.intensity.value = -1f *(slider.normalizedValue) +1f;
     }
      fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
