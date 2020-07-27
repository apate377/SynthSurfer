using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject Car;
    private float CarX, CarZ;

    void Update()
    {
      CarX = Car.transform.position.x;
      CarZ = Car.transform.position.z;
      transform.position = new Vector3(transform.position.x + CarX, transform.position.y , transform.position.z + CarZ);
    }
}
