using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class BedScript : MonoBehaviour
    {
        public BoxCollider boxCollider;
        public static bool reachedEnd = false;

        AudioSource playerAudio;


        void Awake()
        {
            playerAudio = GetComponent<AudioSource>();
        }


        private void OnTriggerEnter(Collider other)
        {
            reachedEnd = true;
            playerAudio.Play();
        }
    }
}