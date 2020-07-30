using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject EnemyBulletPrefab;
    [SerializeField] private Transform EnemyFirePoint;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] GameObject player;
    private bool startShoot = false;
    public NavMeshAgent agent;
    bool chase= false;
    float shootTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (BPSTiming.getCanShoot() == true){
          startShoot = true;
        }
        if (BPSTiming.timeStart > 0){
          shootTime += Time.deltaTime;
        }
        if (Vector3.Distance(player.transform.position, transform.position) < 30f || chase){
          RaycastHit hit;

          Vector3 rayDirection = player.transform.position - transform.position;
          Ray rayToPlayer = new Ray(transform.position, rayDirection);
          Debug.DrawRay(transform.position, rayDirection, Color.white);

          if (Physics.Raycast(rayToPlayer, out hit)) {
            chase = true;
            FacePlayer();
            Shoot();
            agent.SetDestination(player.transform.position);
            print(hit.transform.gameObject.layer);
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player")) {
                //Shoot();
            }
          }
        }
    }

    private void FacePlayer(){
      transform.LookAt(player.transform.position);
    }


    void Shoot(){
      if (shootTime > BPSTiming.getSPB() * .98f) {
         GameObject Enemybullet = Instantiate(EnemyBulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
         Rigidbody rb =Enemybullet.GetComponent<Rigidbody>();
         rb.AddForce(EnemyFirePoint.right * bulletForce, ForceMode.Impulse);
         shootTime = 0f;
       }

    }
}
