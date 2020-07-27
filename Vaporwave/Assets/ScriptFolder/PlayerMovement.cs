using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 200f;
    [SerializeField] private float zSpeed = 200f;
    [SerializeField] private GameObject Car;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject mousePos;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private GameObject Particles, Particles1, Particles2, Particles3;
    private float xInput, zInput;
    private Rigidbody rbCar;

    void Start(){
      rbCar = Car.GetComponent<Rigidbody>();
    }
    void Update()
    {
        CalculatePosition();
        CalculateRotation();
        Shoot();

    }

    private void Shoot() {
      if (CrossPlatformInputManager.GetButtonDown("Fire1") && BPSTiming.getCanShoot() )
      {
        SetGunActive(true);
      }
      else
      {
        SetGunActive(false);
      }
    }

    private void SetGunActive(bool isActive)
    {
      if (isActive){
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody rb =bullet.GetComponent<Rigidbody>();
       rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
     }
    }

    private void CalculatePosition(){
      xInput = CrossPlatformInputManager.GetAxis("Horizontal");
      zInput = CrossPlatformInputManager.GetAxis("Vertical");
      CalculateParticleRotation();
      float xOffset = xInput * xSpeed * Time.deltaTime;
      float zOffset = zInput * zSpeed * Time.deltaTime;
      //float xPos = transform.position.x + xOffset;
      //float zPos = transform.position.z + zOffset;
      rbCar.AddForce(xOffset, 0f, zOffset);
      //Car.transform.position = new Vector3(xPos, transform.position.y, zPos);
      transform.position = new Vector3(Car.transform.position.x, transform.position.y, Car.transform.position.z);
    }
    private void CalculateParticleRotation(){
      float rotationX = 0f;
      float rotationZ = 0f;
      if(xInput < 0){
        rotationX = -30f * xInput;
      } else if (xInput > 0){
        rotationX = -30f * xInput;
      } else if (zInput < 0){
        rotationZ = 30f * zInput;
      } else if (zInput >0){
        rotationZ = 30f * zInput;
      } else if (xInput == 0 && zInput == 0 ){
        rotationX = 0f;
        rotationZ = 0f;
      }
      Particles.transform.rotation = Quaternion.Euler(rotationZ, 0f, rotationX);
      Particles1.transform.rotation = Quaternion.Euler(rotationZ, 0f, rotationX);
      Particles2.transform.rotation = Quaternion.Euler(rotationZ, 0f, rotationX);
      Particles3.transform.rotation = Quaternion.Euler(rotationZ, 0f, rotationX);
    }

    private void CalculateRotation(){
      // float xInput2 = CrossPlatformInputManager.GetAxis("Mouse X");
      // float yInput2 = CrossPlatformInputManager.GetAxis("Mouse Y");
      // float rotation;
      // if (xInput2 > 0f){
      //   rotation = (180/ Mathf.PI)* Mathf.Atan(yInput2/xInput2);
      // }
      // else if (xInput2 < 0f){
      //   rotation = (180/ Mathf.PI)* Mathf.Atan(yInput2/xInput2) + 180;
      // }
      // else if (yInput2 < 0f){
      //   rotation = 90f;
      // }
      // else if (yInput2 > 0f){
      //   rotation = 270f;
      // }
      // else{
      //   rotation = 0f;
      // }
      // Car.transform.localRotation = Quaternion.Euler(0f, rotation, 0f);
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Raycast"))){
        if(hit.transform != null){
            mousePos.transform.position = hit.point;
        }
      }
      if (Vector3.Distance(mousePos.transform.position, Car.transform.position) > 5f){
        Car.transform.LookAt(mousePos.transform.position);
      }
    }
}
