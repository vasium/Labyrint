using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        public GameObject enemyPrefab;
        public Transform spawnPoint;
        public float spawnTime = 17f;


        void Start()
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            spawnPoint = enemyPrefab.transform;
        }


        void Spawn()
        {
            if (playerHealth.currentHealth <= 0f)
            {
                return;
            }

            Instantiate(enemyPrefab, spawnPoint);
        }
    }
}