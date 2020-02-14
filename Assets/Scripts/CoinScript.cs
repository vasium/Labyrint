using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class CoinScript : MonoBehaviour
    {
        public GameObject floatingTextPrefab;
        public GameObject coinObject;
        public GameObject lightObject;
        public BoxCollider coll;
        public AudioSource coinSound;
        public float delayFactor = 1f;
        public static int coinsCollected = 0;

        void Start()
        {
            coinObject = transform.Find("LegoAnimatedFinalSimple").gameObject;
            lightObject = transform.Find("LegoCoinLight").gameObject;
            coinSound = GetComponent<AudioSource>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                coinsCollected += 1;
                coinSound.Play();

                if (gameObject.tag == "PinkTag")
                {
                    ScoreManager.score += 10;
                }
                if (gameObject.tag == "YellowTag")
                {
                    ScoreManager.score += 20;
                }
                if (gameObject.tag == "BlueTag")
                {
                    ScoreManager.score += 40;
                }

                Destroy(coinObject);
                Destroy(lightObject);
                Destroy(coll);
                Destroy(gameObject, delayFactor);

                if (floatingTextPrefab)
                {
                    ShowFloatingText();
                }
            }
        }


        void ShowFloatingText()
        {
            if (gameObject.tag == "PinkTag")
            {
                var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
                go.GetComponent<TextMesh>().text = "+10";
            }
            if (gameObject.tag == "YellowTag")
            {
                var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
                go.GetComponent<TextMesh>().text = "+20";
            }
            if (gameObject.tag == "BlueTag")
            {
                var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
                go.GetComponent<TextMesh>().text = "+40";
            }
        }
    }
}