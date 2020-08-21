using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 200f;
    [SerializeField] private float zSpeed = 200f;
    [SerializeField] private GameObject Car;
    [SerializeField] private Transform firePoint, firePointDual;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject mousePos;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private GameObject Particles, Particles1, Particles2, Particles3;
    private float xInput, zInput;
    private Rigidbody rbCar;
    private bool playerEnabled = true;

    private Vector3 dualOffset = new Vector3(0,0,0.3f);


    void Start(){
      rbCar = Car.GetComponent<Rigidbody>();

      if (UpgradeHandler.dualWielded) {
          firePoint.localPosition -= dualOffset;
      }
    }
    void Update()
    {
      if (playerEnabled){
        CalculatePosition();
        CalculateRotation();
        Shoot();
      }
    }

    private void Shoot() {
      if (CrossPlatformInputManager.GetButtonDown("Fire1") && BPSTiming.getCanShoot() && !PauseMenu.GameIsPaused)
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
      if(isActive) {
        if(UpgradeHandler.dualWielded) {
          GameObject bullet0 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
          Rigidbody rb0 =bullet0.GetComponent<Rigidbody>();
          rb0.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);

          GameObject bullet1 = Instantiate(bulletPrefab, firePointDual.position, firePointDual.rotation);
          Rigidbody rb1 =bullet1.GetComponent<Rigidbody>();
          rb1.AddForce(firePointDual.right * bulletForce, ForceMode.Impulse);
        } else {
         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         Rigidbody rb = bullet.GetComponent<Rigidbody>();
         rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
        }
     }
    }

    private void CalculatePosition(){
      xInput = CrossPlatformInputManager.GetAxis("Horizontal");
      zInput = CrossPlatformInputManager.GetAxis("Vertical");
      CalculateParticleRotation();
      float xOffset = xInput * xSpeed * Time.deltaTime;
      float zOffset = zInput * zSpeed * Time.deltaTime;
      rbCar.AddForce(xOffset, 0f, zOffset);
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
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Raycast"))){
        if(hit.transform != null){
            mousePos.transform.position = hit.point;
        }
      }
      if (Vector3.Distance(mousePos.transform.position, Car.transform.position) > 5f && !PauseMenu.GameIsPaused){
        Car.transform.LookAt(mousePos.transform.position);
      }
    }

    //setters and getters
    public void SetPlayerEnabled(bool set){
      playerEnabled = set;
    }

}
