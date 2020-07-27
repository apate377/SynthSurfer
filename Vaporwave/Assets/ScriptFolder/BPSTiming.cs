using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BPSTiming : MonoBehaviour
    {
        public static float timeStart;
        public static bool canShoot;
        public static float spb;
        [SerializeField] private float bpm = 120f;


        void Start()
        {
          spb = 1f / (bpm / 60f);
          timeStart =spb /2;
        }
        void Update()
        {
            timeStart += Time.deltaTime;
            if (timeStart >= spb){
              timeStart -= spb;
            }
          checkForCanShoot();
        }

        private void checkForCanShoot(){
          if (timeStart < .2 * spb || timeStart > 0.8 * spb)
            {
                canShoot = true;
            }
          else
            {
                canShoot = false;
            }
        }

        //getters and setters

        public static float getSPB(){
          return spb;
        }
        public static bool getCanShoot(){
          return canShoot;

        }

    }
