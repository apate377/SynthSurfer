using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    float startPos;
    public bool useBuffer;
    public bool isSpeaker;
    public bool sizeChange;
    public bool rotation;
    [SerializeField] Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().materials[0];
        if (isSpeaker){
          startPos = transform.localPosition.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer){
          if (!isSpeaker && sizeChange){
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisual.bandBuffer[band] * scaleMultiplier ) + startScale, transform.localScale.z);
          } else if (isSpeaker && sizeChange){
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y , -1f * (AudioVisual.bandBuffer[band] * scaleMultiplier) + startPos);
          } else if (rotation){
            transform.localRotation = Quaternion.Euler(transform.localRotation.x + AudioVisual.bandBuffer[band] * 20, transform.localRotation.y, transform.localRotation.z);
          }
          Color color = new Color (AudioVisual.audioBandBuffer[band], AudioVisual.audioBandBuffer[band], AudioVisual.audioBandBuffer[band]);
          material.SetColor("_EmissionColor", color);
        }
        if (!useBuffer){
          if(!isSpeaker && sizeChange){
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisual.freqBand[band] * scaleMultiplier ) + startScale, transform.localScale.z);
          }
          else if (isSpeaker && sizeChange) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y , -1f * (AudioVisual.freqBand[band] * scaleMultiplier) + startPos);
          } else if (rotation){
            transform.localRotation = Quaternion.Euler(transform.localRotation.x + AudioVisual.freqBand[band] * 20, transform.localRotation.y, transform.localRotation.z);
          }
          Color color = new Color (AudioVisual.audioBand[band], AudioVisual.audioBand[band], AudioVisual.audioBand[band]);
          material.SetColor("_EmissionColor", color);
        }
    }
}
