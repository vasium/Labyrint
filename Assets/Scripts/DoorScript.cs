using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class DoorScript : MonoBehaviour
    {
        public GameObject doorObject;


        void Start()
        {
            doorObject = transform.gameObject;
        }


        void Update()
        {
            if (CoinScript.coinsCollected == 30)
            {
                Destroy(doorObject);
            }
        }
    }
}