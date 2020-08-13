using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FryerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    public NavMeshAgent agent;
    bool chase= false;
    public TimelineController timeline;

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position)< 50f || chase){
          chase= true;
          FacePlayer();
          agent.SetDestination(player.transform.position);
          if(Vector3.Distance(player.transform.position, transform.position) < 20f){
            timeline.Play();
            StartCoroutine(Speed());
          }
        }
    }
    private void FacePlayer(){
      if (Vector3.Distance(player.transform.position, transform.position) > 1f){
        transform.LookAt(player.transform.position);
      }
    }

    private IEnumerator Speed(){
      agent.speed = 0f;
      yield return new WaitForSeconds(.5f);
      agent.acceleration = 20f;
      agent.speed = 30f;
      yield return new WaitForSeconds(.5f);
      agent.acceleration = 8f;
      agent.speed = 10f;
    }
}
